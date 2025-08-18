import { Component, OnInit } from '@angular/core';
import { CursosDemoService, CursoDemo } from '../cursos-demo.service';

@Component({
  selector: 'pm-cursos-lista',
  templateUrl: './cursos-lista.component.html',
  styleUrls: ['./cursos-lista.component.css']
})
export class CursosListaComponent implements OnInit {
  cursos: CursoDemo[] = [];

  constructor(private cursosService: CursosDemoService) {}

  ngOnInit(): void {
    this.cursosService.getCursos().subscribe(data => {
      this.cursos = data;
    });
  }
}
