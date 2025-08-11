import { Component } from '@angular/core';

@Component({
  selector: 'pm-card-demo',
  templateUrl: './card-demo.component.html',
  styleUrl: './card-demo.component.css'
})
export class CardDemoComponent {
  titulo: string = 'Angular con Bootstrap';
  descripcion: string = 'Este es un ejemplo de card en Angular utilizando Bootstrap.';
  imagenUrl: string = 'https://upload.wikimedia.org/wikipedia/commons/6/65/No-Image-Placeholder.svg';
  fecha: string = new Date().toLocaleDateString();
}
