import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UvjetiKoristenjaComponent } from './uvjeti-koristenja.component';

describe('UvjetiKoristenjaComponent', () => {
  let component: UvjetiKoristenjaComponent;
  let fixture: ComponentFixture<UvjetiKoristenjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UvjetiKoristenjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UvjetiKoristenjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
