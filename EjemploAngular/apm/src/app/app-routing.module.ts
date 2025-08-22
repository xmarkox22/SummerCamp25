// ...existing code...
import { PeliculasComponent } from './peliculas/peliculas.component';
import { CursosListaComponent } from './cursos-lista/cursos-lista.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CursoDetalleComponent } from './curso-detalle/curso-detalle.component';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';
import { RegistroComponent } from './registro/registro.component';
import { DemoFormbuilderComponent } from './demo-formbuilder/demo-formbuilder.component';
import { DemoValidacionesComponent } from './demo-validaciones/demo-validaciones.component';
import { PaisesListaComponent } from './paises-lista/paises-lista.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
