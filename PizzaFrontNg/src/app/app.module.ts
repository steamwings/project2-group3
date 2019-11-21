import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
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
import { ReactiveFormsModule } from '@angular/forms';
import { EncrDecrService } from './services/encr-decr.service';


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
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule,
    MatGridListModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    CookieService,
    EncrDecrService
    ],
  bootstrap: [
    AppComponent
    ]
})
export class AppModule { }
