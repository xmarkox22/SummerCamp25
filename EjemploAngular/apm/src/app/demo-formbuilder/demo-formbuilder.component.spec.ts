import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoFormbuilderComponent } from './demo-formbuilder.component';

describe('DemoFormbuilderComponent', () => {
  let component: DemoFormbuilderComponent;
  let fixture: ComponentFixture<DemoFormbuilderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DemoFormbuilderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DemoFormbuilderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
