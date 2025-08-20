import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'pm-registro',
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {


  // Crear un FormGroup con varios FormControl
  formularioRegistro = new FormGroup({
    nombre: new FormControl(''),
    apellido: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl('')
  });


  onSubmit() {
    // Acceder a todo el formulario
    console.log(this.formularioRegistro.value);

    // Acceder a controles individuales
     console.log(this.formularioRegistro.get('email')?.value);


    const emailControl = this.formularioRegistro.get('email');
    console.log(emailControl ? emailControl.value : null);

    // Reiniciar el formulario después de enviar
    this.formularioRegistro.reset();
  }


}
