import { TestBed } from '@angular/core/testing';

import { PoslodavacService } from './poslodavac.service';

describe('PoslodavacService', () => {
  let service: PoslodavacService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PoslodavacService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
