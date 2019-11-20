import { Injectable } from '@angular/core';
import { Topping, IPizzaOption, IOrder, Menu, CrustType, CheeseType, SauceType } from 'src/app/modules/models/models.module';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KrazAPIService {
  private baseUrl = 'https://krazpizza.azurewebsites.net';

  constructor(private http:HttpClient) { }
  
  private getTypes<T extends IPizzaOption>(uri: string): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl + uri);
  }

  getCrustTypes(): Observable<CrustType[]>{
    return this.getTypes<CrustType>('/api/crusttypes');
  }
  
  getCheeseTypes(): Observable<CheeseType[]> {
    return this.getTypes<CheeseType>('/api/cheesetypes');
  }

  getSauceTypes(): Observable<SauceType[]> {
    return this.getTypes<SauceType>('/api/saucetypes');
  }

  getToppings(): Observable<Topping[]> {
    return this.getTypes<Topping>('/api/toppings');
  }

  getMenu(): Observable<Menu> {
    return this.http.get<Menu>(this.baseUrl + '/api/menu');
  }
  
  placeOrder(order : IOrder){
    return this.http.post(this.baseUrl + '/api/orders', order)
  }

  registerCustomer(customer){

   const headers = new HttpHeaders().set( 'Content-Type','application/json', )

    return this.http.post('https://krazpizza.azurewebsites.net/api/customers', customer, {headers})
  }

  logInCustomer(customer){

    const headers = new HttpHeaders().set( 'Content-Type','application/json' )

    return this.http.post('https://krazpizza.azurewebsites.net/api/customers/login', customer, {headers})

    
  }

  getSalt(email){

    const headers = new HttpHeaders().set( 'Content-Type','application/json' )

    return this.http.post('https://krazpizza.azurewebsites.net/api/customers/salt', email, {headers,responseType: 'text'})

    
  }
    
}
