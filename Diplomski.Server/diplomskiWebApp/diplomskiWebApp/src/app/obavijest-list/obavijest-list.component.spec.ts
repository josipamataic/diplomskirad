import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObavijestListComponent } from './obavijest-list.component';

describe('ObavijestListComponent', () => {
  let component: ObavijestListComponent;
  let fixture: ComponentFixture<ObavijestListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObavijestListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObavijestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
