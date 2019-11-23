import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators,FormControl,FormArray } from '@angular/forms';
import { Pizza, Topping, CrustType, CheeseType, SauceType } from 'src/app/modules/models/models.module';
import { KrazAPIService } from 'src/app/services/kraz-api.service';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

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
  crustList: Array<CrustType>;
  cheeseList: Array<CheeseType>;
  sauceList: Array<SauceType>;
  toppingsLoaded: Promise<boolean>;
  crustLoaded: Promise<boolean>;
  cheeseLoaded: Promise<boolean>;
  sauceLoaded: Promise<boolean>;
  // Selections
  toppings : Array<number>;
  sauce: number;
  cheese: number;
  // TODO: Form validation
  allowSubmit = false;
  setting = "start";

  constructor(private fb: FormBuilder, 
              private api: KrazAPIService,
              private cart: ShoppingCartService)
  {
    this.dynForm = new FormGroup({});

    this.api.getCrustTypes().subscribe(crusts => { 
      this.crustList = crusts;
      this.createRadioControl('crust'); 
      this.crustLoaded = Promise.resolve(true);
    });

    this.api.getSauceTypes().subscribe(sauces => {
      this.sauceList = sauces;
      this.createRadioControl('sauce');
      this.sauceLoaded = Promise.resolve(true);
    });

    this.api.getCheeseTypes().subscribe(cheeses => {
      this.cheeseList = cheeses;
      this.createRadioControl('cheese');
      this.cheeseLoaded = Promise.resolve(true);
    });
    
    this.api.getToppings().subscribe(loadedToppings => {
      this.toppingsList = loadedToppings;
      this.dynForm.addControl('toppings', this.fb.array(this.toppingsList.map(_ => false)));
      this.dynForm.controls['toppings'].valueChanges.subscribe(() => {
        var vals = this.dynForm.controls['toppings'].value;
        this.toppings = vals.map((val, index) => val ? this.toppingsList[index].id : '').filter(e => e != '');
      });
      this.toppingsLoaded = Promise.resolve(true);
      this.setting = "stop";
    });
    
    Promise.all([this.crustLoaded, this.sauceLoaded, this.cheeseLoaded, this.toppingsLoaded])
    .then(() => {
        this.allowSubmit = true;
    }).catch(() =>{
        console.log("Promises failed!");
    });

  }

  createRadioControl(name) {
    this.dynForm.addControl(name, this.fb.control({ name: ['Cannot be empty.', Validators.required] }));
    this.dynForm.controls[name].setValue(1);
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

    if(this.dynForm.invalid){
      //TODO Show error
      console.log("Invalid");
      return;
    }
    var pizza = new Pizza();
    pizza.cheeseTypesId = this.dynForm.controls['cheese'].value;
    pizza.crustTypesId = this.dynForm.controls['crust'].value;
    pizza.sauceTypesId = this.dynForm.controls['sauce'].value;
    pizza.toppingsId = this.toppings;
    this.cart.addPizza(pizza);
    console.log(JSON.stringify(pizza));
  }

}
