import {NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderListComponent } from './components/order-list/order-list.component';
import { LoginComponent } from './components/login/login.component';
import { OrderPizzaComponent } from './components/order-pizza/order-pizza.component'
import { FormsModule, ReactiveFormsModule } from'@angular/forms';
import { MatCheckboxModule,
        MatFormFieldModule,
        MatRadioModule,
        MatIconModule,
        MatSelectModule,
        MatInputModule  } from '@angular/material';




const routes: Routes = [
    {path:'login', component: LoginComponent},
    {path:'orders', component : OrderListComponent},
    {path : 'orderpizza' , component : OrderPizzaComponent }
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
export const routingComponents =[LoginComponent,OrderListComponent, OrderPizzaComponent]