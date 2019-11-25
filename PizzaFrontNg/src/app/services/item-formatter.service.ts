import { Injectable } from '@angular/core';
import { KrazAPIService } from './kraz-api.service';
import { Item, Pizza, ItemType } from '../modules/models/models.module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemFormatterService {

  constructor(private api: KrazAPIService) { }

  format(p: Pizza, index: number) : Observable<Item>{
    var obs = new Observable<Item>(subscriber =>
    {
      this.api.getMenu().subscribe(menu =>{
        var desc = menu.crusts.find(c => c.id == p.crustTypesId).name + ", ";
        desc += menu.sauces.find(s => s.id == p.sauceTypesId).name + ", ";
        desc += menu.cheeses.find(c => c.id == p.cheeseTypesId).name;
        if(p.toppingsId) p.toppingsId.forEach(tid => desc += ", " + menu.toppings.find(t => t.id == tid).name);
        var item = new Item({
        name:"Custom Pizza", description:desc, price:"TBD", 
        type:ItemType.Pizza, index:index
        });
        subscriber.next(item);
      });
    });
    return obs;
  }

  formatSide(id: number, index: number) : Item{
    return new Item({name:"side", type:ItemType.Side, index:index});
  }

  formatePrebuiltPizza(id: number, index: number) : Item{
    return new Item({name:"prebuilt pizza", type:ItemType.PrebuiltPizza, index:index});
  }

  emptyItem() : Observable<Item>{
    return new Observable<Item>(sub => 
      sub.next(new Item({name:"No items.", description:"-", price:"-", type:ItemType.Meta, index:0})
    ));
  }

}
