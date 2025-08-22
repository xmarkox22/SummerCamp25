import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CounterdemoComponent } from './counterdemo/counterdemo.component';
import { CardDemoComponent } from './card-demo/card-demo.component';
<<<<<<< HEAD
import { Peliculas } from './peliculas/peliculas';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';
import { RouterModule } from '@angular/router';
=======
import { PeliculasComponent } from './peliculas/peliculas.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CursosListaComponent } from './cursos-lista/cursos-lista.component';
import { CursoDetalleComponent } from './curso-detalle/curso-detalle.component';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';
import { RegistroComponent } from './registro/registro.component';
import { DemoFormbuilderComponent } from './demo-formbuilder/demo-formbuilder.component';
import { DemoValidacionesComponent } from './demo-validaciones/demo-validaciones.component';
import { PaisesListaComponent } from './paises-lista/paises-lista.component';
import { PaisDetalleComponent } from './pais-detalle/pais-detalle.component';
>>>>>>> caabf0da35491bce2eec8ac13a3a410f508f9357

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    CounterdemoComponent,
    CardDemoComponent,
<<<<<<< HEAD
    Peliculas,
    DemoFormReactivoComponent
=======
    PeliculasComponent,
    CursosListaComponent,
    CursoDetalleComponent,
    DemoFormReactivoComponent,
    RegistroComponent,
    DemoFormbuilderComponent,
    DemoValidacionesComponent,
    PaisesListaComponent
  ,PaisDetalleComponent
>>>>>>> caabf0da35491bce2eec8ac13a3a410f508f9357
  ],
  // ...existing code...
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
<<<<<<< HEAD
    ReactiveFormsModule
=======
     ReactiveFormsModule
>>>>>>> caabf0da35491bce2eec8ac13a3a410f508f9357
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }