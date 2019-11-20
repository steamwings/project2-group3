import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IOrder, IPizza, Pizza, Order } from '../interfaces/models';

@Injectable({
  providedIn: 'root'
})

export class ShoppingCartService {

  constructor(private cookies: CookieService) { }

  private currentPizza : IPizza = null;

  private Cart() : IOrder {
    if(!this.cookies.check('cart')){
      return new Order();
    }
    return JSON.parse(this.cookies.get('cart'));
  }

  private Save(cart : IOrder){
    this.cookies.set('cart', JSON.stringify(cart));
  }

  private checkNullPizza(){
    if(this.currentPizza == null){
      this.currentPizza = new Pizza();
    }
  }

  public startPizza(){
    this.currentPizza = new Pizza();
  }

  // TODO use Number.isInteger() to validate
  public crust(crustId : number){
    this.checkNullPizza();
    this.currentPizza.crustTypesId = crustId;
  }

  public sauce(sauceId: number) {
    this.checkNullPizza();
    this.currentPizza.sauceTypesId = sauceId;
  }

  public cheese(cheeseId: number) {
    this.checkNullPizza();
    this.currentPizza.cheeseTypesId = cheeseId;
  }

  public topping(toppingId: number) {
    this.checkNullPizza();
    this.currentPizza.toppingsId.push(toppingId);
  }

  public pizza() {
    var cart = this.Cart();
    cart.pizzas.push(this.currentPizza);
    this.Save(cart);
  }

  public addSide(sideId : number) {
    var cart = this.Cart();
    cart.sidesIds.push(sideId);
    this.Save(cart);
  }

}