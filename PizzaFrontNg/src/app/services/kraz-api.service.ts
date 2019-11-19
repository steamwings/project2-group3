import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { IPizza } from '../interfaces/type-interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KrazAPIService {

  constructor(private http:HttpClient) { }

  getPizzas(): Observable<IPizza[]>{
    
    return this.http.get<IPizza[]>('https://krazpizza.azurewebsites.net/api/crusttypes');
  }
  
  placeOrder(order){

    return this.http.post('https://krazpizza.azurewebsites.net/api/orders',order)
  }

  registerCustomer(customer){

   const headers = new HttpHeaders().set( 'Content-Type','application/json', )

    return this.http.post('https://krazpizza.azurewebsites.net/api/customers', customer, {headers})
  }

    
}
