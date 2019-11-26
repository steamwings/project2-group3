import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


// TODO: This file is called a module, but it's not really one!
// @NgModule({
//   declarations: [],
//   imports: [
//     CommonModule
//   ]
// })
// export class ModelsModule { }

// TODO: Sizes are "Large", "Medium", "Small"
export enum ItemType{
  Pizza,
  PrebuiltPizza,
  Side,
  Meta
}

export class Item{
  name: string;
  description: string;
  price: string;
  nprice: number
  type: ItemType; 
  index: number;

  public constructor(
    fields?: {
      name?: string,
      description?: string,
      price?: string,
      nprice?: number,
      type: ItemType,
      index: number
    }
  ){
    if (fields) Object.assign(this, fields);
  }
}

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
  toppingsId: Array<number> = new Array<number>();
}

export interface IOrder {
  customerId: number,
  pizzas: Array<IPizza>,
  sidesIds: Array<number>,
  premadePizzaIds: Array<number>,
  orderTime: string //TODO Remove
}

export class Order implements IOrder {
  customerId: number | null;
  pizzas: Array<IPizza> = new Array<Pizza>();
  sidesIds: Array<number> = new Array<number>();
  premadePizzaIds: Array<number> = new Array<number>();
  orderTime: string = "2014-01-01T23:28:56.782Z"; //TODO Remove
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
  price: number;
}

export class Side implements IPizzaOption {
  id: number;
  name: string;
  description: string;
  price: number;
}

export class CrustType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
  price: number;
}

export class SauceType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
  price: number;
}

export class CheeseType implements IPizzaOption {
  id: number;
  name: string;
  description: string;
  price: number;
}

export class Menu {
  crusts: Array<CrustType>;
  cheeses: Array<CheeseType>;
  sauces: Array<SauceType>;
  sides: Array<Side>;
  toppings: Array<Topping>;
}
