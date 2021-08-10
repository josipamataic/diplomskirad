import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KandidatiOglasComponent } from './kandidati-oglas.component';

describe('KandidatiOglasComponent', () => {
  let component: KandidatiOglasComponent;
  let fixture: ComponentFixture<KandidatiOglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KandidatiOglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KandidatiOglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
