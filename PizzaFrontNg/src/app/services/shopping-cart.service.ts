import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor(private cookies: CookieService) { }

  private Cart(){
    this.cookies.get('cart')
  }

  public addPizza(pizza) {
    this.cookies.set('cart', 'haspizza');
  }


}