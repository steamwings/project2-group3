import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Item, ItemType } from 'src/app/modules/models/models.module';
import { Observable } from 'rxjs';
import { MatTableDataSource, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})

export class ShoppingCartComponent implements OnInit {

  items: Observable<Array<Item>>;
  price: Observable<string>;
  columnsToDisplay = ['name', 'price', 'description', 'remove'];
  get ItemType() { return ItemType; }

  constructor(
    private cart: ShoppingCartService,
  ){ 
    this.items = cart.getItems();
    this.price = cart.getPrice();
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
    //TODO snackbar undo option
  }

  clear(){
    this.cart.clear();
  }

}
