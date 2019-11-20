import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ModelsModule { }

// Sizes are "Large", "Medium", "Small"

export interface IPizza {
  crustTypesId: number,
  cheeseTypesId: number,
  sauceTypesId: number,
  size: string,
  toppingsId: Array<number>
}

export class Pizza implements IPizza {
  crustTypesId: number;
  cheeseTypesId: number;
  sauceTypesId: number;
  size: string;
  toppingsId: Array<number>;
}

export interface IOrder {
  pizzas: Array<IPizza>,
  sidesIds: Array<number>,
  customerId: Number,
  orderTime: string //TODO Remove
}

export class Order implements IOrder {
  pizzas: Array<IPizza>;
  sidesIds: Array<number>;
  customerId: number;
  orderTime: string; //TODO Remove
}

export interface IPizzaOption {
  id: number,
  name: string,
  description: string
}

export class Topping implements IPizzaOption {
  id: number;
  name: string;
  description: string;
}

export class Side implements IPizzaOption {
  id: number;
  name: string;
  description: string;
}

export class CrustType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
}

export class SauceType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
}

export class CheeseType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
}

export class Menu {
  cheeses: Array<CheeseType>;
  sauces: Array<SauceType>;
  sides: Array<Side>;
  toppings: Array<Topping>;
}
