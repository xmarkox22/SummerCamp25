import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { Peliculas } from './peliculas/peliculas';
import { DemoFormReactivoComponent } from './demo-form-reactivo/demo-form-reactivo.component';

const routes: Routes = [
  { path: 'peliculas', component: Peliculas },
  { path: 'demo-form-reactivo', component: DemoFormReactivoComponent },
  { path: '', component: WelcomeComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
