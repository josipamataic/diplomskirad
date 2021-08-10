import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateoglasComponent } from './createoglas.component';

describe('CreateoglasComponent', () => {
  let component: CreateoglasComponent;
  let fixture: ComponentFixture<CreateoglasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateoglasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateoglasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
