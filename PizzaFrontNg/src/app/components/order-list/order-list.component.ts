import { Component, OnInit } from '@angular/core';
import {KrazAPIService } from '../../services/kraz-api.service'

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  public pizzas=[];

  constructor(private _getPizzaService : KrazAPIService) { }

  ngOnInit() {
    this._getPizzaService.getPizzas()
    .subscribe( data => this.pizzas = data );
    console.log(this.pizzas);
  }

}
