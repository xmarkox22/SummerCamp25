import { Component, OnDestroy, OnInit } from '@angular/core';
import { PeliculasService, IPelicula } from './peliculas.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'pm-peliculas',
  templateUrl: './peliculas.html',
  styleUrls: ['./peliculas.css']
})
export class Peliculas implements OnInit, OnDestroy {
  peliculas: IPelicula[] = [];
  errorMessage: string = '';
  loading: boolean = true;
  sub!: Subscription;

  constructor(private peliculasService: PeliculasService) {}

  ngOnDestroy(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.loading = true;
    this.sub = this.peliculasService.getPeliculas().subscribe({
      next: data => {
        this.peliculas = Array.isArray(data) ? data : [];
        this.loading = false;
      },
      error: err => {
        this.errorMessage = err;
        this.loading = false;
      }
    });
  }
}