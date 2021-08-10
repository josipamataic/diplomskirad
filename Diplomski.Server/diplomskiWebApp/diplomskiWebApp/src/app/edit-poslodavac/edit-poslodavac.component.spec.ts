import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPoslodavacComponent } from './edit-poslodavac.component';

describe('EditPoslodavacComponent', () => {
  let component: EditPoslodavacComponent;
  let fixture: ComponentFixture<EditPoslodavacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPoslodavacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPoslodavacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
