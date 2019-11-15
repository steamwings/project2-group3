import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { IPizza } from '../interfaces/pizza';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KrazAPIService {

  constructor(private http:HttpClient) { }

  getPizzas(): Observable<IPizza[]>{
    return this.http.get<IPizza[]>('https://krazpizza.azurewebsites.net/api/crusttypes');
  }
}
