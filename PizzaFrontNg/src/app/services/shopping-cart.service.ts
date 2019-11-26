import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IOrder, IPizza, Pizza, Order, Item, Menu } from 'src/app/modules/models/models.module';
import { Observable, zip, Subject, BehaviorSubject } from 'rxjs';
import { ItemFormatterService } from './item-formatter.service';

@Injectable({
  providedIn: 'root'
})

export class ShoppingCartService {

  constructor(private cookies: CookieService,
              private formatter: ItemFormatterService,
  ) { }

  private subject : Subject<Item[]>;

  private Cart() : IOrder {
    if(!this.cookies.check('cart')){
      return new Order();
    }
    return JSON.parse(this.cookies.get('cart'));
  }

  public getAndClear() : IOrder {
    var ret = null;
    if (this.cookies.check('cart')) {
      ret = this.Cart();
    }
    this.Save(new Order()); // Clear 
    return ret;
  }

  private Save(cart : IOrder){
    this.cookies.set('cart', JSON.stringify(cart));
    this.CastChanges();
  }

  private CastChanges(){
    if (this.subject) {
      zip(...this.formatAsItems()).subscribe(v => {
        this.subject.next(v);
      });
    }
  }

  public clear() {
    this.Save(new Order());
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

  // TODO Add prebuiltpizza methods

  public removePizza(index: number){
    var cart = this.Cart();
    cart.pizzas = cart.pizzas.filter((_, i) => index != i );
    this.Save(cart); 
  }

  public removeSide(index: number){
    var cart = this.Cart();
    cart.sidesIds = cart.sidesIds.filter((_, i) => { index != i } );
    this.Save(cart);
  }

  private formatAsItems() : Observable<Item>[]{
    var list = new Array<Observable<Item>>();
    var cart = this.Cart();
    if(cart.pizzas)
      cart.pizzas.forEach((p, index) => {
        list.push(this.formatter.format(p, index));
      });
    if(cart.sidesIds)
      cart.sidesIds.forEach((s, index) => {
        list.push(this.formatter.formatSide(s, index));
      });
    if (cart.premadePizzaIds)
      cart.premadePizzaIds.forEach((p, index) => {
        list.push(this.formatter.formatPremadePizza(p, index));
      });
    if(list.length==0)
      list.push(this.formatter.emptyItem());
    return list;
  }

  public getItems() : Observable<Item[]>{
    if(!this.subject) this.subject = new BehaviorSubject<Item[]>([]);
    this.CastChanges();
    return this.subject;
  }

  public getPrice() : Observable<string>{
    if (!this.subject) this.getItems();
    var obs = new Observable<string>(sub => {
      this.subject.subscribe(items => {
        let total: number = 0;
        items.forEach(i => total += i.nprice);
        sub.next(this.formatter.formatPrice(total));
      });
    });
    return obs;
  }

}