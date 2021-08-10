import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsPoslodavacComponent } from './details-poslodavac.component';

describe('DetailsPoslodavacComponent', () => {
  let component: DetailsPoslodavacComponent;
  let fixture: ComponentFixture<DetailsPoslodavacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsPoslodavacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsPoslodavacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
