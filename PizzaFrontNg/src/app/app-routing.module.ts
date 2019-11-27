import {NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderListComponent } from './components/order-list/order-list.component';
import { LoginLandingComponent } from './components/login-landing/login-landing.component';
import { OrderPizzaComponent } from './components/order-pizza/order-pizza.component'
import { FormsModule, ReactiveFormsModule } from'@angular/forms';
import { MatCheckboxModule,
        MatFormFieldModule,
        MatRadioModule,
        MatIconModule,
        MatSelectModule,
        MatInputModule  } from '@angular/material';

import { RegisterComponent } from './components/register/register.component';
import { LoginComponent} from './components/login/login.component'
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { LogoutComponent } from './components/logout/logout.component';
import { OrderSidesComponent } from './components/order-sides/order-sides.component';
import { LandingContentComponent } from './components/landing-content/landing-content.component';


const routes: Routes = [
    {path: '', component: LandingContentComponent},
    {path: 'home', component: LandingContentComponent}, //TODO add real home
    {path: 'loginlanding', component: LoginLandingComponent},
    {path: 'orders', component: OrderListComponent},
    {path: 'orderpizza' , component: OrderPizzaComponent },
    {path: 'orderside', component: OrderSidesComponent},
    {path: 'register' , component: RegisterComponent },
    {path: 'login' , component: LoginComponent },
    {path: 'logout', component: LogoutComponent},
    {path: 'cart', component: ShoppingCartComponent},
    {path: 'checkout', component: CheckoutComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes),
        FormsModule,
        ReactiveFormsModule,
        MatCheckboxModule,
        MatRadioModule,
        MatFormFieldModule,
        MatIconModule,
        MatSelectModule,
        MatInputModule,
        
    ],
    exports: [RouterModule,
        FormsModule,
        ReactiveFormsModule,
        MatCheckboxModule,
        MatRadioModule,
        MatFormFieldModule,
        MatIconModule,
        MatSelectModule,
        MatInputModule
        ]
})

export class AppRoutingModule{ }
export const routingComponents =[LoginComponent,OrderListComponent, OrderPizzaComponent,RegisterComponent,LoginLandingComponent, LandingContentComponent]