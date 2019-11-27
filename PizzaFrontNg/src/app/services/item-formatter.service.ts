import { Injectable } from '@angular/core';
import { KrazAPIService } from './kraz-api.service';
import { Item, Pizza, ItemType, IPizzaOption } from '../modules/models/models.module';
import { Observable } from 'rxjs';
import { formatCurrency } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ItemFormatterService {
  private locale = "en-US";

  constructor(private api: KrazAPIService) { }

  formatPrice(price: number) : string {
    return formatCurrency(price, this.locale, "$");
  }

  formatPizza(p: Pizza, index: number) : Observable<Item>{
    var obs = new Observable<Item>(subscriber =>
    {
      this.api.getMenu().subscribe(menu =>{
        var crust = menu.crusts.find(c => c.id == p.crustTypesId);
        var sauce = menu.sauces.find(s => s.id == p.sauceTypesId);
        var cheese = menu.cheeses.find(c => c.id == p.cheeseTypesId);
        var desc = crust.name + ", " + sauce.name + ", " + cheese.name;
        let price: number = crust.price + sauce.price + cheese.price;
        if(p.toppingsId) p.toppingsId.forEach(tid => {
          var topping = menu.toppings.find(t => t.id == tid);
          desc += ", " + topping.name;
          price += topping.price;
        });
        var item = new Item({
          name:"Custom Pizza", description:desc, nprice:price, 
          price:this.formatPrice(price), 
          type:ItemType.Pizza, index:index
        });
        subscriber.next(item);
      });
    });
    return obs;
  }

  private format(id: number, index: number, listname: string){
    var obs = new Observable<Item>(subscriber => {
      this.api.getMenu().subscribe(menu => {
        let array: Array<IPizzaOption> = menu[listname];
        let pOption: IPizzaOption = array.find((s: IPizzaOption) => s.id == id);
        var item = new Item({
          name: pOption.name, 
          description: pOption.description,
          nprice: pOption.price,
          price: this.formatPrice(pOption.price),
          type: ItemType.Side, 
          index: index
        });
        subscriber.next(item);
      });
    });
    return obs;
  }

  formatSide(id: number, index: number) : Observable<Item>{
    return this.format(id, index, "sides");
  }

  formatPremadePizza(id: number, index: number) : Observable<Item>{
    return this.format(id, index, "premadePizzas");
  }

  emptyItem() : Observable<Item>{
    return new Observable<Item>(sub => 
      sub.next(new Item({name:"No items.", description:"-", price:"-", nprice:0, type:ItemType.Meta, index:0})
    ));
  }

}
