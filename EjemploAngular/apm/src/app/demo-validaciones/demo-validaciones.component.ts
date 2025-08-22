import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'pm-demo-validaciones',
  templateUrl: './demo-validaciones.component.html',
  styleUrl: './demo-validaciones.component.css'
})
export class DemoValidacionesComponent {
  formularioContacto: any;
  hoy: string = new Date().toISOString().split('T')[0];
  roles: string[] = [
    'Administrador',
    'Usuario',
    'Editor',
    'Invitado',
    'SuperAdministrador'
  ];

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
      ]],
      fechaNacimiento: ['', [Validators.required, this.fechaMinimaValidator, this.fechaMaximaValidator]],
      rol: ['', [Validators.required, this.rolValidoValidator]],
      dadoDeAlta: [false, []],
      estadoCivil: ['', [Validators.required]],
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

get fechaNacimiento() {
  return this.formularioContacto.get('fechaNacimiento');
}

get rol() {
  return this.formularioContacto.get('rol');
}

get dadoDeAlta() {
  return this.formularioContacto.get('dadoDeAlta');
}

get estadoCivil() {
  return this.formularioContacto.get('estadoCivil');
}

estadoCivilOpciones: string[] = [
  'Soltero',
  'Casado',
  'Divorciado',
  'Separado',
  'Pareja de hecho',
  'Viudo'
];

  // Validador: fecha mínima (por ejemplo, 01/01/1900)
  fechaMinimaValidator(control: any) {
    if (!control.value) return null;
    const minDate = new Date('1900-01-01');
    const inputDate = new Date(control.value);
    return inputDate >= minDate ? null : { fechaMinima: true };
  }

  // Validador: fecha máxima (no puede ser mayor a hoy)
  fechaMaximaValidator(control: any) {
    if (!control.value) return null;
    const maxDate = new Date();
    const inputDate = new Date(control.value);
    return inputDate <= maxDate ? null : { fechaMaxima: true };
  }

  // Validador personalizado para rol
  rolValidoValidator = (control: any) => {
    return this.roles.includes(control.value) ? null : { rolInvalido: true };
  }

  onSubmit() {
    if (this.formularioContacto.valid) {
      console.log('Datos enviados:', this.formularioContacto.value);
      // Aquí puedes agregar lógica adicional, como mostrar un mensaje o limpiar el formulario
    }
  }
}
