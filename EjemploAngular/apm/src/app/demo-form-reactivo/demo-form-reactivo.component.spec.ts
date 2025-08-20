import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoFormReactivoComponent } from './demo-form-reactivo.component';

describe('DemoFormReactivoComponent', () => {
  let component: DemoFormReactivoComponent;
  let fixture: ComponentFixture<DemoFormReactivoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DemoFormReactivoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DemoFormReactivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
