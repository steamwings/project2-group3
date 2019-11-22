import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service';
import { EncrDecrService } from '../../services/encr-decr.service'
import { SessionCookieService } from '../../services/session-cookie.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  hide = true;

  email = new FormControl('', );


  constructor(private fb: FormBuilder, 
    private KrazService: KrazAPIService,
    private SessionCookie:SessionCookieService,
    private EncrDecr : EncrDecrService) { }

  ngOnInit() {

    this.loginForm = this.fb.group({

      password: new FormControl(''),
      email: new FormControl('',[Validators.required, Validators.email]),
      
  })
  }

  logIn(){
    
    let promise = this.KrazService.getSalt({"email":this.loginForm.value.email}).toPromise()


    promise.then((salt)=>{

      let passwordHash = this.EncrDecr.setLogin(this.loginForm.value.password, salt);
      let email = this.loginForm.value.email;
      let logInObj = new Object();

      logInObj["Email"] = email;
      logInObj["PasswordHash"] = passwordHash;
        
      console.log(logInObj)
      this.KrazService.logInCustomer(logInObj).subscribe( response => this.SessionCookie.setUserID(response) )



    }).catch((error)=>{
      console.log("Promise rejected with " + JSON.stringify(error));
    });



    

    
  }

}
