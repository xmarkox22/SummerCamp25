import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';


@Component({
  selector: 'pm-card-demo',
  templateUrl: './card-demo.component.html',
  styleUrl: './card-demo.component.css'
})
export class CardDemoComponent  {
  @Input() titulo: string = '';
  @Input() descripcion: string = '';
  @Input() imagenUrl: string = '';
  @Input() fecha: string = '';
  @Input() autor: string = '';
  @Input() id: number = 0; // Agregado para manejar el ID del curso

  @Output() seleccionar = new EventEmitter<string>();





  mostrarNombre() {
    this.seleccionar.emit(this.titulo);
  }
}
