import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolitikaPrivatnostiComponent } from './politika-privatnosti.component';

describe('PolitikaPrivatnostiComponent', () => {
  let component: PolitikaPrivatnostiComponent;
  let fixture: ComponentFixture<PolitikaPrivatnostiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolitikaPrivatnostiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolitikaPrivatnostiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
