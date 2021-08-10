import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPoslodavciComponent } from './list-poslodavci.component';

describe('ListPoslodavciComponent', () => {
  let component: ListPoslodavciComponent;
  let fixture: ComponentFixture<ListPoslodavciComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPoslodavciComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPoslodavciComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
