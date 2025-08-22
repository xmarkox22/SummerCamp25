import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'pm-demo-formbuilder',
  templateUrl: './demo-formbuilder.component.html',
  styleUrl: './demo-formbuilder.component.css'
})
export class DemoFormbuilderComponent {

  // Inyectar FormBuilder
  formularioRegistro: any;

  constructor(private fb: FormBuilder) {
    // Crear formulario con FormBuilder
    this.formularioRegistro = this.fb.group({
      nombre: ['', Validators.required],
      apellido: [''],
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      direccion: this.fb.group({
        calle: [''],
        ciudad: [''],
        codigoPostal: ['']
      })
    });
  }

  onSubmit() {
    if (this.formularioRegistro.valid) {
      console.log('Datos del formulario:', this.formularioRegistro.value);
      // Aquí puedes agregar lógica para enviar los datos o mostrar un mensaje
    }
  }

}
