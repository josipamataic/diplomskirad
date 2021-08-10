import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAllOglasComponent } from './list-all-oglas.component';

describe('ListAllOglasComponent', () => {
  let component: ListAllOglasComponent;
  let fixture: ComponentFixture<ListAllOglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListAllOglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListAllOglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
