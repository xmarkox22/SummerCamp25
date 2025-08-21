import { Component, OnInit } from '@angular/core';
import { PaisesService, Pais } from '../paises.service';

@Component({
  selector: 'app-paises-lista',
  templateUrl: './paises-lista.component.html',
  styleUrls: ['./paises-lista.component.css']
})
export class PaisesListaComponent implements OnInit {
  paises: Pais[] = [];
  nombre: string = '';
  idioma: string = '';
  paginaActual: number = 1;
  tamanoPagina: number = 10;

  constructor(private paisesService: PaisesService) {}

  ngOnInit(): void {
    this.cargarPaises();
  }

  cargarPaises(): void {
  this.paisesService.getPaises(this.idioma, this.nombre, this.paginaActual, this.tamanoPagina)
      .subscribe(paises => this.paises = paises);
  }

  buscar(): void {
    this.paginaActual = 1;
  this.cargarPaises();
  }

  paginaSiguiente(): void {
    this.paginaActual++;
  this.cargarPaises();
  }

  paginaAnterior(): void {
    if (this.paginaActual > 1) {
      this.paginaActual--;
      this.cargarPaises();
    }
  }
}
