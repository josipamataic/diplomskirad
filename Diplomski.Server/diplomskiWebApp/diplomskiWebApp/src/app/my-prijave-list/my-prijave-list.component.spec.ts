import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyPrijaveListComponent } from './my-prijave-list.component';

describe('MyPrijaveListComponent', () => {
  let component: MyPrijaveListComponent;
  let fixture: ComponentFixture<MyPrijaveListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyPrijaveListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyPrijaveListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
