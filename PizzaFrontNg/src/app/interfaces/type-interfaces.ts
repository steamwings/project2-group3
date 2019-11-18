export interface IPizza {
    toppings:Array<Object>,
    CrustTypesId: Number,
    CheeseTypesId: Number,
    SauceTypesId: Number,
    Size:string,
    ToppingsId:Array<Number>
}

export interface IOrder {
    Pizzas: Array<IPizza>,
    SidesIds: Array<Number>,
    CustomerId: Number,
    OrderTime: string //TODO Remove
}