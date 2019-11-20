import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl,FormArray } from '@angular/forms';
import { KrazAPIService } from '../../services/kraz-api.service';
import { CheckboxComponent } from '../checkbox/checkbox.component';
import { CheckboxGroupComponent } from '../checkbox-group/checkbox-group.component';
import { tap } from 'rxjs/operators';
import { Pizza, Topping } from 'src/app/interfaces/models';
import { assertNotNull } from '@angular/compiler/src/output/output_ast';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-order-pizza',
  templateUrl: './order-pizza.component.html',
  styleUrls: ['./order-pizza.component.css'],
  providers: []
})

export class OrderPizzaComponent implements OnInit {
  
  orderForm: FormGroup;
  dynForm: FormGroup;
  toppingsList: Array<Topping>;
  toppingsLoaded: Promise<boolean>;
  toppings : Array<number>;
  allowSubmit = false;

  constructor(private fb: FormBuilder, 
              private api: KrazAPIService)
  {
    this.dynForm = new FormGroup({});
    this.api.getToppings().subscribe(loadedToppings => 
    {
      this.toppingsList = loadedToppings;
      var toppingsSelected = this.toppingsList.map(_ => false);
      console.log("ts:" + toppingsSelected);
      var a = this.fb.array(toppingsSelected);
      this.dynForm.addControl('toppings', a);
      this.dynForm.controls['toppings'].valueChanges.subscribe(() => {
        var v = this.dynForm.controls['toppings'].value;
        this.toppings = v.map((b, index) => b ? this.toppingsList[index].id : '' ).filter(e => e!='');
      });
      this.toppingsLoaded = Promise.resolve(true);
      this.allowSubmit = true;
    }
    );
  }

  ngOnInit() {
    this.orderForm = this.fb.group({
      crust: new FormControl(''),
      sauce: new FormControl(''),
      cheese: new FormControl(''),
      toppings: new FormControl(''),  
    });
  }

  addPizza(){

    console.log(  );
    var pizza = new Pizza();
    pizza.toppingsId = this.orderForm.value.toppings
    console.log(this.orderForm.value.toppings);

    //this.KrazService.placeOrder(order).subscribe(response=> console.log(response))

  }

}
