import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoValidacionesComponent } from './demo-validaciones.component';

describe('DemoValidacionesComponent', () => {
  let component: DemoValidacionesComponent;
  let fixture: ComponentFixture<DemoValidacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DemoValidacionesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DemoValidacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
