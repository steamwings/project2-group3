import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { BehaviorSubject, Observable } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class SessionCookieService {

  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor( private cookieService: CookieService ) { 
    if(this.cookieService.check('UserID') && parseInt(this.cookieService.get('UserID'),10) > 0) {
        this.loggedIn.next(true);
    }
  }

  setUserID(id :string){
    this.cookieService.set('UserID', id)
    if(id != null) this.loggedIn.next(true);
    console.log( "from the cookie service", this.cookieService.get('UserID'))
  }

  getUserID(){
    return this.cookieService.get('UserID');
  }

  isLoggedIn() : Observable<boolean>{ //TODO Make Observable
    return this.loggedIn.asObservable();
  }

  logOut(){
    this.cookieService.set('UserID', '');
    this.loggedIn.next(false);
  }

}
