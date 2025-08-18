import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'pm-counterdemo',
  templateUrl: './counterdemo.component.html',
  styleUrls: ['./counterdemo.component.css']
})
export class CounterdemoComponent implements OnInit {
  @Input() initialValue: number = 0;
  contador: number = 0;

  ngOnInit() {
    this.contador = this.initialValue;
  }

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
