import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CounterdemoComponent } from './counterdemo/counterdemo.component';
import { CardDemoComponent } from './card-demo/card-demo.component';
import { PeliculasComponent } from './peliculas/peliculas.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CursosListaComponent } from './cursos-lista/cursos-lista.component';
import { CursoDetalleComponent } from './curso-detalle/curso-detalle.component';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    CounterdemoComponent,
    CardDemoComponent,
    PeliculasComponent,
    CursosListaComponent,
    CursoDetalleComponent,
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