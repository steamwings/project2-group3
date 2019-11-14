import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { LandingGridComponent } from './landing-grid/landing-grid.component';
import { FooterComponent } from './footer/footer.component';
import { LandingContentComponent } from './landing-content/landing-content.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    LandingGridComponent,
    FooterComponent,
    LandingContentComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent
    ]
})
export class AppModule { }
