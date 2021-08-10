import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsOglasComponent } from './details-oglas.component';

describe('DetailsOglasComponent', () => {
  let component: DetailsOglasComponent;
  let fixture: ComponentFixture<DetailsOglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsOglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsOglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
