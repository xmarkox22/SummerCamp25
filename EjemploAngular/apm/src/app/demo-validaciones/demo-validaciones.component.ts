import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'pm-demo-validaciones',
  templateUrl: './demo-validaciones.component.html',
  styleUrl: './demo-validaciones.component.css'
})
export class DemoValidacionesComponent {
  formularioContacto: any;

  constructor(private fb: FormBuilder) {
    this.formularioContacto = this.fb.group({
      nombre: ['', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(50)
      ]],
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      mensaje: ['', [
        Validators.required,
        Validators.minLength(10)
      ]],
      edad: [null, [
        Validators.min(18),
        Validators.max(120)
      ]],
      telefono: ['', [
        Validators.pattern('[0-9]{9}')
      ]]
    });
  }

// Getters para acceso simplificado
get nombre() {
  return this.formularioContacto.get('nombre');
}

get email() {
  return this.formularioContacto.get('email');
}

get mensaje() {
  return this.formularioContacto.get('mensaje');
}

get edad() {
  return this.formularioContacto.get('edad');
}

get telefono() {
  return this.formularioContacto.get('telefono');
}


  onSubmit() {
    if (this.formularioContacto.valid) {
      console.log('Datos enviados:', this.formularioContacto.value);
      // Aquí puedes agregar lógica adicional, como mostrar un mensaje o limpiar el formulario
    }
  }
}
