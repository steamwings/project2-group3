import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IOrder, IPizza, Pizza, Order, Item, Menu, ItemType } from 'src/app/modules/models/models.module';
import { Observable, zip, Subject, BehaviorSubject } from 'rxjs';
import { ItemFormatterService } from './item-formatter.service';
import { supportsScrollBehavior } from '@angular/cdk/platform';

@Injectable({
  providedIn: 'root'
})

export class ShoppingCartService {

  constructor(private cookies: CookieService,
              private formatter: ItemFormatterService,
  ){
    this.countSubject = new BehaviorSubject<number>(0);
    this.itemsSubject = new BehaviorSubject<Item[]>([]);
    this.priceSubject = new BehaviorSubject<string>("$0.00");
    this.Save(this.Cart());
  }

  ngOnInit(){
    // this.itemsSubject.subscribe(i =>{
    //   console.log("Items: " + i);
    // });
  }

  private itemsSubject: Subject<Item[]>;
  private countSubject: Subject<number>;
  private priceSubject: Subject<string> = null;
  private count: number = 0;

  public getCount() : Observable<number>{
    return this.countSubject.asObservable();
  }

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
    this.count = cart.pizzas.length + cart.premadePizzaIds.length + cart.sidesIds.length;
    this.cookies.set('cart', JSON.stringify(cart));
    this.CastChanges();
  }

  private CastChanges(){
    this.formatter.formatAsItems(this.Cart())
    .subscribe(v => {
      this.itemsSubject.next(v);
      let total: number = 0;
      v.forEach(i => total += i.nprice);
      this.priceSubject.next(this.formatter.formatPrice(total));
    });
    this.countSubject.next(this.count);
  }

  public clear() {
    this.Save(new Order());
  }

  public addPizza(p: Pizza) {
    var cart = this.Cart();
    cart.pizzas.push(p);
    this.Save(cart);
  }

  public addSide(sideId: number) {
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
    cart.sidesIds = cart.sidesIds.filter((_, i) => index != i );
    this.Save(cart);
  }

  public getItems() : Observable<Item[]>{
    this.CastChanges();
    return this.itemsSubject.asObservable();
  }


  public getPrice() : Observable<string>{
    return this.priceSubject.asObservable();
  }

}