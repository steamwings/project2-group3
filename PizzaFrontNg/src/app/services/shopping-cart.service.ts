import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IOrder, IPizza, Pizza, Order, Item, Menu } from 'src/app/modules/models/models.module';
import { listLazyRoutes } from '@angular/compiler/src/aot/lazy_routes';
import { KrazAPIService } from './kraz-api.service';
import { Observable, zip } from 'rxjs';
import { ItemFormatterService } from './item-formatter.service';

@Injectable({
  providedIn: 'root'
})

export class ShoppingCartService {

  constructor(private cookies: CookieService,
              private api: KrazAPIService,
              private formatter: ItemFormatterService,
  ) { }

  private currentPizza : IPizza = null;

  /* TODOish: We *should* have a mutex to ensure this doesn't get called from 
     multiple places. We could probably use Observables to synchronize as well,
     but let's avoid that work unless we have to do it.
  */
  private Cart() : IOrder {
    if(!this.cookies.check('cart')){
      return new Order();
    }
    return JSON.parse(this.cookies.get('cart'));
  }

  private Save(cart : IOrder){
    this.cookies.set('cart', JSON.stringify(cart));
  }

  public addPizza(p: Pizza) {
    var cart = this.Cart();
    cart.pizzas.push(p);
    this.Save(cart);
  }

  public addSide(sideId : number) {
    var cart = this.Cart();
    cart.sidesIds.push(sideId);
    this.Save(cart);
  }

  private formatAsItems() : Observable<Item>[]{
    var list = new Array<Observable<Item>>();
    var cart = this.Cart();
    if(cart.pizzas)
      cart.pizzas.forEach(p => {
        list.push(this.formatter.format(p));
      });
    list.push(this.formatter.emptyItem());
    return list;
  }

  public getItems() : Observable<Item[]>{
    return zip(...this.formatAsItems());
  }

}