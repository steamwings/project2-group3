import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from 'src/app/services/kraz-api.service';
import { Side, Item, ItemType } from 'src/app/modules/models/models.module';
import { Observable } from 'rxjs';
import { ItemFormatterService } from 'src/app/services/item-formatter.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-order-sides',
  templateUrl: './order-sides.component.html',
  styleUrls: ['./order-sides.component.css']
})

export class OrderSidesComponent implements OnInit {

  sides: Observable<Item[]>;
  columnsToDisplay = ['add', 'name', 'price', 'description'];
  get ItemType() { return ItemType; }

  constructor(
    private api: KrazAPIService,
    private cart: ShoppingCartService,
    formatter: ItemFormatterService,
    private snackbar: MatSnackBar,
  ){
    this.sides = Observable.create(sub =>{
      this.api.getMenu().subscribe(m => {
        let sItems: Item[] = new Array<Item>(); 
        m.sides.forEach((s: Side) => sItems.push(new Item({
          name: s.name,
          description: s.description,
          nprice: s.price,
          price: formatter.formatPrice(s.price),
          type: ItemType.Side,
          index: s.id
        })));
        sub.next(sItems);
      });
    });
  }

  ngOnInit() {
  }

  add(i: Item){
    this.cart.addSide(i.index);
    let sbRef = this.snackbar.open(i.name + " added to Cart.", "Add another");
    sbRef.onAction().subscribe(() => {
      this.add(i);
    });
  }

}
