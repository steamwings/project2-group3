import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators'
import { KrazAPIService } from 'src/app/services/kraz-api.service';
import { Router } from '@angular/router';
import { SessionCookieService } from 'src/app/services/session-cookie.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  price: Observable<string>;
  disabled: boolean = true;
  paid: boolean = false; // when true, buttons are disabled
  order: Observable<string>;

  constructor(private cart: ShoppingCartService,
              private api: KrazAPIService,
              private cookieSvc: SessionCookieService,
              private router: Router) {
    this.price = cart.getPrice();
    this.price.subscribe(p => {
      this.disabled = !this.paid && (p == "$0.00"); 
    });
   }

  ngOnInit() {
  }

  submitOrder(){
    // This subscribe will dispose after the first value
    this.cookieSvc.isLoggedIn().pipe(first()).subscribe(loggedIn => {
      if(!loggedIn) this.router.navigate(['/loginlanding']);
      else {
        var myOrder = this.cart.getAndClear();
        myOrder.customerId = parseInt(this.cookieSvc.getUserID());
        console.log(myOrder);
        this.order = this.api.placeOrder(myOrder);
        this.paid = this.disabled = true;
        // this.router.navigate(['/orderconfirm']);
      }
    }); 
  }

}
