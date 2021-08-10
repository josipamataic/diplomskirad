import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListKandidatiComponent } from './list-kandidati.component';

describe('ListKandidatiComponent', () => {
  let component: ListKandidatiComponent;
  let fixture: ComponentFixture<ListKandidatiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListKandidatiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListKandidatiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
