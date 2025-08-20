import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'pm-curso-detalle',
  templateUrl: './curso-detalle.component.html',
  styleUrl: './curso-detalle.component.css'
})
export class CursoDetalleComponent implements OnInit {
  id: number = 0;

   constructor(private route: ActivatedRoute,private router: Router) {}
  ngOnInit(): void {
    /*
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    */
    this.id = this.route.snapshot.params['id'];
  }

  volver() {
    //window.history.back();
    this.router.navigate(['/cursos']);
  }

}
