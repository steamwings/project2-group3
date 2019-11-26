import { Component, OnInit } from '@angular/core';
import { SessionCookieService } from 'src/app/services/session-cookie.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private cookieSvc: SessionCookieService) { 
    cookieSvc.logOut();
  }

  ngOnInit() {
  }

}
