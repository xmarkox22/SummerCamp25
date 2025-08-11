import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  template: `<div>
                <h1>{{ title }}</h1>
                <div>Mi primer componente</div>
                <pm-welcome></pm-welcome>
                <pm-counterdemo></pm-counterdemo>
                <pm-card-demo></pm-card-demo>
             </div>` 
})
export class AppComponent {
  title = 'apm ver 1.0';
}
