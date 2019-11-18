import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl,FormArray } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service'


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

  orderPizza(orderData){

    
    console.log(this.orderForm.value.toppings);

    this.KrazService.placeOrder(orderData).subscribe(response=> console.log(response))
  }

}
