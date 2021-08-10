import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KandidatiPoslodavacComponent } from './kandidati-poslodavac.component';

describe('KandidatiPoslodavacComponent', () => {
  let component: KandidatiPoslodavacComponent;
  let fixture: ComponentFixture<KandidatiPoslodavacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KandidatiPoslodavacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KandidatiPoslodavacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
