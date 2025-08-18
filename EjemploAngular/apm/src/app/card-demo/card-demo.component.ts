import { Component, Input } from '@angular/core';

@Component({
  selector: 'pm-card-demo',
  templateUrl: './card-demo.component.html',
  styleUrl: './card-demo.component.css'
})
export class CardDemoComponent {
  @Input() titulo: string = '';
  @Input() descripcion: string = '';
  @Input() imagenUrl: string = '';
  @Input() fecha: string = '';
  @Input() autor: string = '';
}
