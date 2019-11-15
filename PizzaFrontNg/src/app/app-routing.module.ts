import {NgModule} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderListComponent } from './components/order-list/order-list.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
    {path:'login', component: LoginComponent},
    {path:'orders', component : OrderListComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{ }
export const routingComponents =[LoginComponent,OrderListComponent]