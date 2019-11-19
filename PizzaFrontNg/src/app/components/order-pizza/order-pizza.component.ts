import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl,FormArray } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service';
import { CheckboxComponent } from '../checkbox/checkbox.component';
import { CheckboxGroupComponent } from '../checkbox-group/checkbox-group.component';
import { tap } from 'rxjs/operators';
 
@Component({
  selector: 'app-order-pizza',
  templateUrl: './order-pizza.component.html',
  styleUrls: ['./order-pizza.component.css']
})

export class OrderPizzaComponent implements OnInit {
  
  orderForm: FormGroup;


  constructor(private fb: FormBuilder, 
              private KrazService: KrazAPIService)
             {}
  

  ngOnInit() {

    this.orderForm = this.fb.group({
      crust: new FormControl(''),
      sauce: new FormControl(''),
      cheese: new FormControl(''),
      toppings: new FormControl(''),
      
  })
  }

  orderPizza(){

    console.log( this.orderForm.value.toppings );

    var orderObject = {
      "Pizzas": [
          {
              "CrustTypesId": 1,
              "CheeseTypesId": 1,
              "SauceTypesId": 1,
              "Size": "Large",
              "ToppingsId": [ 1, 2, 3]
          }
      ],
      "SidesIds": [
          1,
          2
      ],
      "CustomerId": 15,
      "OrderTime": "2019-11-15T17:00:00.000Z"
   };

  
 

    this.KrazService.placeOrder({
      "Pizzas": [
          {
              "CrustTypesId": 1,
              "CheeseTypesId": 1,
              "SauceTypesId": 1,
              "Size": "Large",
              "ToppingsId": [ 1, 2, 3]
          }
      ],
      "SidesIds": [
          1,
          2
      ],
      "CustomerId": 15,
      "OrderTime": "2019-11-15T17:00:00.000Z"
   }).subscribe(response=> console.log(response))

  }

}
