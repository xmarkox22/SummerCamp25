import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

export interface IPelicula {
  title: string;
  episode_id: number;
  opening_crawl: string;
  director: string;
  producer: string;
  release_date: string;
  // Agrega más campos si los necesitas
}

@Injectable({
  providedIn: 'root'
})
export class PeliculasService {
  private peliculasUrl = 'https://swapi.online/api/films';

  constructor(private http: HttpClient) { }

  getPeliculas(): Observable<IPelicula[]> {
    return this.http.get<IPelicula[]>(this.peliculasUrl).pipe(
      tap(data => console.log('Peliculas: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }


  private handleError(err: HttpErrorResponse): Observable<never> {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `Ocurrió un error: ${err.error.message}`;
    } else {
      errorMessage = `El servidor retornó el código: ${err.status}, mensaje: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(() => errorMessage);
  }
}
