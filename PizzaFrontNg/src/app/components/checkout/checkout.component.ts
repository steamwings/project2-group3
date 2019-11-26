import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { Observable } from 'rxjs';
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
    this.cookieSvc.isLoggedIn().subscribe(loggedIn => {
      if(!loggedIn) this.router.navigate(['/loginlanding']);
      else{
        var myOrder = this.cart.getAndClear();
        myOrder.customerId = parseInt(this.cookieSvc.getUserID());
        console.log(myOrder);
        this.api.placeOrder(myOrder).subscribe(order => {
          console.log("Got back: " + order);
        });
        this.paid = this.disabled = true;
      }
    }); 
  }

}
