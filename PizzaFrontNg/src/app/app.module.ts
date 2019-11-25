import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatMenuModule, MatButtonModule, MatTableModule, 
  MatGridListModule } from '@angular/material';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { LandingGridComponent } from './components/landing-grid/landing-grid.component';
import { FooterComponent } from './components/footer/footer.component';
import { LandingContentComponent } from './components/landing-content/landing-content.component';
import { AppRoutingModule, routingComponents} from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { CheckboxGroupComponent } from './components/checkbox-group/checkbox-group.component';
import { CookieService } from 'ngx-cookie-service';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ShoppingCartService } from './services/shopping-cart.service';
import { ReactiveFormsModule } from '@angular/forms';
import { EncrDecrService } from './services/encr-decr.service'
import { KrazAPIService } from './services/kraz-api.service';
//import { ModelsModule } from './modules/models/models.module';
import { ItemFormatterService } from './services/item-formatter.service';
import { OrderSidesComponent } from './components/order-sides/order-sides.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LandingGridComponent,
    FooterComponent,
    LandingContentComponent,
    routingComponents,
    CheckboxComponent,
    CheckboxGroupComponent,
    ShoppingCartComponent,
    OrderSidesComponent,    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule,
    MatTableModule,
    MatGridListModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
 //   ModelsModule,
  ],
  providers: [
    CookieService,
    EncrDecrService,
    KrazAPIService,
    ShoppingCartService,
    ItemFormatterService,
    ],
  bootstrap: [
    AppComponent
    ]
})
export class AppModule { }
