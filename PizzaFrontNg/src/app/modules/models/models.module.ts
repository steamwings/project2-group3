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
  orderTime: string; //TODO Remove
}

export class DisplayOrder extends Order {
  items: string;
  price: string;

  public constructor(o : Order, it: string, pr: string){
    super();
    Object.assign(this, o);
    this.items = it;
    this.price = pr;
  }
}

export interface IPizzaOption {
  id: number,
  name: string,
  description: string,
  price: number,
}

class PizzaOption implements IPizzaOption {
  id: number;  
  name: string;
  description: string;
  price: number;
}

export class Topping extends PizzaOption {}
export class Side extends PizzaOption {}
export class CrustType extends PizzaOption {}
export class SauceType extends PizzaOption {}
export class CheeseType extends PizzaOption {}
export class PremadePizza extends PizzaOption {}

export class Menu {
  crusts: Array<CrustType>;
  cheeses: Array<CheeseType>;
  sauces: Array<SauceType>;
  sides: Array<Side>;
  toppings: Array<Topping>;
  premadePizzas: Array<PremadePizza>;
}
