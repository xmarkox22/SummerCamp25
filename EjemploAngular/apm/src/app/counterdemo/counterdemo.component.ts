import { Component } from '@angular/core';

@Component({
  selector: 'pm-counterdemo',
  templateUrl: './counterdemo.component.html',
  styleUrl: './counterdemo.component.css'
})
export class CounterdemoComponent {
    contador: number = 0;

    incrementar() {
        this.contador++;
    }

    decrementar() {
        this.contador--;
    }

  reiniciar() {
    this.contador = 0;
  }
}
