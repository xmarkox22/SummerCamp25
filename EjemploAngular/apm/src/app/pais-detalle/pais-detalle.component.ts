import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaisesService, Pais } from '../paises.service';

@Component({
  selector: 'app-pais-detalle',
  templateUrl: './pais-detalle.component.html',
  styleUrls: ['./pais-detalle.component.css']
})
export class PaisDetalleComponent implements OnInit {
  pais: Pais | null = null;

  constructor(private route: ActivatedRoute, private paisesService: PaisesService) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.paisesService.getPais(+id).subscribe((data: Pais) => {
        this.pais = data;
      });
    }
  }
}
