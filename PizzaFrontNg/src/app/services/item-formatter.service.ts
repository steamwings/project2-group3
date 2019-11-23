import { Injectable } from '@angular/core';
import { KrazAPIService } from './kraz-api.service';
import { Item, Pizza } from '../modules/models/models.module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemFormatterService {

  constructor(private api: KrazAPIService) { }

  format(p: Pizza) : Observable<Item>{
    var obs = new Observable<Item>(subscriber =>
    {
      this.api.getMenu().subscribe(menu =>{
        var desc = menu.crusts.find(c => c.id == p.crustTypesId).name + ", ";
        desc += menu.cheeses.find(c => c.id == p.cheeseTypesId).name;
        desc += "Cheese, " + menu.
        var item = new Item({
        name:"Custom Pizza", description:desc, price:"TBD"
        });
        subscriber.next(item);
      });
    });
    return obs;
  }

  formatSide(id: number) : Item{
    return new Item({name:"side"});
  }

  formatePrebuiltPizza(id: number) : Item{
    return new Item({name:"prebuilt pizza"});
  }

  emptyItem() : Observable<Item>{
    return new Observable<Item>(sub => 
      sub.next(new Item({name:"No items.", description:"-", price:"-"})
    ));
  }

}
