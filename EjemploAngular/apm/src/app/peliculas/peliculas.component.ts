import { Component, OnDestroy, OnInit } from '@angular/core';
import { PeliculasService, IPelicula } from './peliculas.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pm-peliculas',
  templateUrl: './peliculas.component.html',
  styleUrls: ['./peliculas.component.css']
})
export class PeliculasComponent implements OnInit, OnDestroy {
  peliculas: IPelicula[] = [];
  errorMessage: string = '';
  sub!: Subscription;
  
  constructor(private peliculasService: PeliculasService) {}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnInit(): void {
    this.sub = this.peliculasService.getPeliculas().subscribe({
      next: data => {
        this.peliculas = data;
      },
      error: err => this.errorMessage = err
    });
  }
}
