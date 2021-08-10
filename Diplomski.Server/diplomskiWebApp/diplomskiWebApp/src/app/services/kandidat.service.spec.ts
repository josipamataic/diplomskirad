import { TestBed } from '@angular/core/testing';

import { KandidatService } from './kandidat.service';

describe('KandidatService', () => {
  let service: KandidatService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KandidatService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
