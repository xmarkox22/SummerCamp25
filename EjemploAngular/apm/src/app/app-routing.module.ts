import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PeliculasComponent } from './peliculas/peliculas.component';
import { CursosListaComponent } from './cursos-lista/cursos-lista.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CursoDetalleComponent } from './curso-detalle/curso-detalle.component';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';

const routes: Routes = [

    { path: 'cursos', component: CursosListaComponent },
    { path: 'peliculas', component: PeliculasComponent },
    { path: 'curso-detalle/:id', component: CursoDetalleComponent },
    { path: 'demo-form-reactivo', component: DemoFormReactivoComponent },
    { path: 'demo-form-registro', component: DemoFormRegistroComponent },

    { path: '', component: WelcomeComponent },
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
