import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { BehaviorSubject, Observable } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class SessionCookieService {

// Reference to look into Behaviour Subject Pattern
//isUserID = new BehaviorSubject<string>(this.getID());
//
//getID(){
//Method to initially acquire user ID when they log in
//  return '23'
//}


  constructor( private cookieService: CookieService ) { }


  setUserID(id :string){

    this.cookieService.set('UserID', id)

    console.log( "from the cookie service", this.cookieService.get('UserID'))

  }

  getUserID(){

    return this.cookieService.get('UserID')
  }

}
