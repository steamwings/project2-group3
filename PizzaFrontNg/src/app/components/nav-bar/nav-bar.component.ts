import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from 'src/app/services/kraz-api.service';
import { CookieService } from 'ngx-cookie-service';
import { SessionCookieService } from 'src/app/services/session-cookie.service';
import { Observable } from 'rxjs';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedIn: Observable<boolean>
  cartCount: Observable<number>
  
  constructor(private cookieSvc: SessionCookieService,
              private cart: ShoppingCartService,
  ) { 
    this.loggedIn = cookieSvc.isLoggedIn();
    this.cartCount = cart.getCount();
  }

  ngOnInit() {
  }

}
