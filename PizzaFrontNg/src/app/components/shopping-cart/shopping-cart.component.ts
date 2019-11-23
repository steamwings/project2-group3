import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Item } from 'src/app/modules/models/models.module';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})

export class ShoppingCartComponent implements OnInit {

  items: Observable<Array<Item>>;
  
  constructor(cart: ShoppingCartService) { 
    this.items = cart.getItems();
    this.items.subscribe(val => {console.log("Item: " + val)});
  }

  ngOnInit() {
  }

}
