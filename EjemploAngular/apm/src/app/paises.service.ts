import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Pais {
  id?: number;
  nombre: string;
  idioma?: string;
  capital?: string;
  fechaInicioTemporadaAlta?: string;
  fechaFinTemporadaAlta?: string;
}

export interface PaisesPaginados {
  paises: Pais[];
  totalRegistros: number;
}

@Injectable({ providedIn: 'root' })
export class PaisesService {
  private apiUrl = 'https://localhost:7228/api/paises';

  constructor(private http: HttpClient) {}

  getPaises(
    idioma?: string,
    nombre?: string,
    numeroPagina: number = 1,
    tamanoPagina: number = 5
  ): Observable<PaisesPaginados> {
    let params = new HttpParams();
    if (idioma) params = params.set('idioma', idioma);
    if (nombre) params = params.set('nombre', nombre);
    params = params.set('numeroPagina', numeroPagina.toString());
    params = params.set('tamañoPagina', tamanoPagina.toString());
    return this.http.get<PaisesPaginados>(this.apiUrl, { params });
  }

  getPais(id: number): Observable<Pais> {
    return this.http.get<Pais>(`${this.apiUrl}/${id}`);
  }

  addPais(pais: Pais): Observable<Pais> {
    return this.http.post<Pais>(this.apiUrl, pais);
  }

  updatePais(id: number, pais: Pais): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, pais);
  }

  deletePais(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
