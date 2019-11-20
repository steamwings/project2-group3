import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service';
import { EncrDecrService } from '../../services/encr-decr.service'
import { subscribeOn } from 'rxjs/operators';


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
    private EncrDecr : EncrDecrService) { }

  ngOnInit() {

    this.loginForm = this.fb.group({

      password: new FormControl(''),
      email: new FormControl('',[Validators.required, Validators.email]),
      
  })
  }

  logIn(){
    
    let salt;

    this.KrazService.getSalt({"email":this.loginForm.value.email}).subscribe(response=> console.log(response))
    

    this.EncrDecr.setLogin(this.loginForm.value.password)

    // let logInObj = new Object();
    // let hashwSalt = this.EncrDecr.set(this.loginForm.value.password);


    // logInObj['Email'] = this.loginForm.value.email;
    // logInObj['PasswordHash'] = hashwSalt.hash;

    // let jsonlogInObj = JSON.stringify(logInObj);


    // this.KrazService.logInCustomer(jsonlogInObj).subscribe( response => console.log(response))

  }

}
