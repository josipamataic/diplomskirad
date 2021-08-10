import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOglasComponent } from './list-oglas.component';

describe('ListOglasComponent', () => {
  let component: ListOglasComponent;
  let fixture: ComponentFixture<ListOglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListOglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
