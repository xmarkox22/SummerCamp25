  // ...existing code...
import { Component, OnInit } from '@angular/core';
import { PaisesService, Pais, PaisesPaginados } from '../paises.service';

@Component({
  selector: 'app-paises-lista',
  templateUrl: './paises-lista.component.html',
  styleUrls: ['./paises-lista.component.css']
})
export class PaisesListaComponent implements OnInit {
  irPrimeraPagina(): void {
    if (this.paginaActual !== 1) {
      this.paginaActual = 1;
      this.cargarPaises();
    }
  }

  irUltimaPagina(): void {
    if (this.paginaActual !== this.totalPaginas) {
      this.paginaActual = this.totalPaginas;
      this.cargarPaises();
    }
  }
  resetFiltros(): void {
    this.nombre = '';
    this.idioma = '';
    this.paginaActual = 1;
    this.cargarPaises();
  }
  paises: Pais[] = [];
  totalRegistros: number = 0;
  nombre: string = '';
  idioma: string = '';
  paginaActual: number = 1;
  tamanoPagina: number = 10;
  totalPaginas: number = 1;

  constructor(private paisesService: PaisesService) {}

  ngOnInit(): void {
    this.cargarPaises();
  }

  cargarPaises(): void {
    this.paisesService.getPaises(this.idioma, this.nombre, this.paginaActual, this.tamanoPagina)
      .subscribe((resp: PaisesPaginados) => {
        this.paises = resp.paises;
        this.totalRegistros = resp.totalRegistros;
        this.totalPaginas = this.totalRegistros > 0 ? Math.ceil(this.totalRegistros / this.tamanoPagina) : 1;
      });
  }

  buscar(): void {
    this.paginaActual = 1;
  this.cargarPaises();
  }

  paginaSiguiente(): void {
    if ((this.paginaActual * this.tamanoPagina) < this.totalRegistros) {
      this.paginaActual++;
      this.cargarPaises();
    }
  }

  paginaAnterior(): void {
    if (this.paginaActual > 1) {
      this.paginaActual--;
      this.cargarPaises();
    }
  }
}
