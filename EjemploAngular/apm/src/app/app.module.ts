import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CounterdemoComponent } from './counterdemo/counterdemo.component';
import { CardDemoComponent } from './card-demo/card-demo.component';
import { Peliculas } from './peliculas/peliculas';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    CounterdemoComponent,
    CardDemoComponent,
    Peliculas,
    DemoFormReactivoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }