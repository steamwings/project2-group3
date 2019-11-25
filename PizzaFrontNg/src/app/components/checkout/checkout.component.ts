import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  price: Observable<string>;
  disabled: boolean = true;

  constructor(cart: ShoppingCartService) {
    this.price = cart.getPrice();
    this.price.subscribe(p => {
      this.disabled = (p == "$0.00"); 
    })
   }

  ngOnInit() {
  }

}
