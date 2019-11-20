import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service';
import { EncrDecrService } from '../../services/encr-decr.service'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  hide = true;

  email = new FormControl('', );
  
  constructor(private fb: FormBuilder, 
              private KrazService: KrazAPIService,
              private EncrDecr : EncrDecrService) { }
  
  

  ngOnInit() {

    this.registerForm = this.fb.group({
      firstname: new FormControl(''),
      lastname: new FormControl(''),
      password: new FormControl(''),
      email: new FormControl('',[Validators.required, Validators.email])    
  })

  }

  registerCustomer(){
    let password = this.registerForm.value.password;
    let hashwSalt = this.EncrDecr.set(password);
    let regObj = new Object();

    regObj["FirstName"] = this.registerForm.value.firstname;
    regObj["LastName"] = this.registerForm.value.lastname;
    regObj["PasswordHash"] = hashwSalt.hash;
    regObj["Salt"] = hashwSalt.salt;
    regObj["Email"] = this.registerForm.value.email;
    
   //let jsonRegObj = JSON.stringify(regObj);

    console.log(regObj)
   
    this.KrazService.registerCustomer(regObj)
    .subscribe( response => console.log(response))

  }


  // getErrorMessage() {


  //   return this.email.hasError('required') ? 'You must enter a value' :
  //       this.email.hasError('email') ? 'Not a valid email' :
  //           '';
  // }

}
