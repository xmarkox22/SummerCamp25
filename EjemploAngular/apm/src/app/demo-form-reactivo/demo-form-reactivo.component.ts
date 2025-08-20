import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'pm-demo-form-reactivo',
  templateUrl: './demo-form-reactivo.component.html',
  styleUrl: './demo-form-reactivo.component.css'
})
export class DemoFormReactivoComponent {


  // FormControl con valor inicial
  nombre = new FormControl('Juan');

  // FormControl vacío
  apellido = new FormControl('');

  actualizarNombre() {
    // Establecer valor programáticamente
    this.nombre.setValue('Carlos');
  }

  reiniciar() {
    // Restablecer al valor inicial
    this.nombre.reset();
  }

}

