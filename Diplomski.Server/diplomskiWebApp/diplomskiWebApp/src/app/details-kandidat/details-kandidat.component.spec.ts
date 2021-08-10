import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsKandidatComponent } from './details-kandidat.component';

describe('DetailsKandidatComponent', () => {
  let component: DetailsKandidatComponent;
  let fixture: ComponentFixture<DetailsKandidatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsKandidatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsKandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
