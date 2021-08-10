import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoslodavacOglasComponent } from './poslodavac-oglas.component';

describe('PoslodavacOglasComponent', () => {
  let component: PoslodavacOglasComponent;
  let fixture: ComponentFixture<PoslodavacOglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoslodavacOglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoslodavacOglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
