import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from 'src/app/services/kraz-api.service';
import { CookieService } from 'ngx-cookie-service';
import { SessionCookieService } from 'src/app/services/session-cookie.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedIn: Observable<boolean>
  
  constructor(private cookieSvc: SessionCookieService) { 
    this.loggedIn = cookieSvc.loggedIn;
  }

  ngOnInit() {
  }

}
