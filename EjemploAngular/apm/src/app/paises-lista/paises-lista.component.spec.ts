import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PaisesListaComponent } from './paises-lista.component';
import { PaisesService } from '../paises.service';
import { of } from 'rxjs';

class MockPaisesService {
  getPaises() { return of([]); }
}

describe('PaisesListaComponent', () => {
  let component: PaisesListaComponent;
  let fixture: ComponentFixture<PaisesListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaisesListaComponent ],
      providers: [ { provide: PaisesService, useClass: MockPaisesService } ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaisesListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
