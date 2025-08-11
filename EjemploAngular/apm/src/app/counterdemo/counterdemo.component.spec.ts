import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterdemoComponent } from './counterdemo.component';

describe('CounterdemoComponent', () => {
  let component: CounterdemoComponent;
  let fixture: ComponentFixture<CounterdemoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CounterdemoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CounterdemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
