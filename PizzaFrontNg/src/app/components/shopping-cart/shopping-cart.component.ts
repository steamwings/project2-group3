import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Item, ItemType } from 'src/app/modules/models/models.module';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})

// TODO: Get table padding to actually work
export class ShoppingCartComponent implements OnInit {

  items: Observable<Array<Item>>;
  columnsToDisplay = ['name', 'price', 'description', 'remove'];
  
  constructor(private cart: ShoppingCartService) { 
    this.items = cart.getItems();
    //this.items.subscribe(val => {console.log("Item: " + val)});
  }

  ngOnInit() {
  }

  remove(item: Item){
    switch(item.type){
      case ItemType.Pizza:
        this.cart.removePizza(item.index);
        break;
      case ItemType.PrebuiltPizza:
        //TODO
        break;
      case ItemType.Side:
        this.cart.removeSide(item.index);
        break;
      case ItemType.Meta:
      default:
    }
  }

  clear(){
    this.cart.clear();
  }

}
