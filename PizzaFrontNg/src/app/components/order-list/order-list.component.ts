import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from '../../services/kraz-api.service'
import { Observable, zip, BehaviorSubject, Subject } from 'rxjs';
import { IOrder, DisplayOrder, ItemType } from 'src/app/modules/models/models.module';
import { ItemFormatterService } from 'src/app/services/item-formatter.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  private orders: Subject<DisplayOrder[]> = new BehaviorSubject<DisplayOrder[]>([]);
  columnsToDisplay = [/*'reorder',*/ 'price', 'time', 'description',];
  private formattedOrders: DisplayOrder[];

  constructor(api : KrazAPIService,
    formatter: ItemFormatterService,  
  ) {
    
    api.getOrders().subscribe(orders => {
      //console.log(JSON.stringify(o));
      this.formattedOrders = new Array<DisplayOrder>();
      orders.forEach(o => {
        formatter.formatAsItems(o).subscribe(items =>{
          var itemsStr: string = "";
          var price: number = 0;
          items.forEach(i =>{
            switch(i.type){
              case ItemType.Pizza:
                itemsStr += i.description + ", ";
                break;
              case ItemType.Meta:
                break;
              default:
                itemsStr += i.name + ", ";
                break;
            }
            price += i.nprice;
          });
          var dispOrder = new DisplayOrder(o, itemsStr, formatter.formatPrice(price));
          dispOrder.orderTime = formatter.formatDate(dispOrder.orderTime);
          this.formattedOrders.push(dispOrder);
          this.orders.next(this.formattedOrders);
        });
      });
    });
    
   }

  ngOnInit() {

  }

  reorder(o: DisplayOrder){
    //TODO
  }

}
