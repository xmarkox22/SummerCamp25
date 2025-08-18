import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CursoDemo {
  titulo: string;
  descripcion: string;
  imagenUrl: string;
  fecha: string;
  autor: string;
}

@Injectable({ providedIn: 'root' })
export class CursosDemoService {
  private cursosUrl = 'assets/cursos-demo.json';

  constructor(private http: HttpClient) {}

  getCursos(): Observable<CursoDemo[]> {
    return this.http.get<CursoDemo[]>(this.cursosUrl);
  }
}
