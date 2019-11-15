import { TestBed } from '@angular/core/testing';

import { KrazAPIService } from './kraz-api.service';

describe('KrazAPIService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: KrazAPIService = TestBed.get(KrazAPIService);
    expect(service).toBeTruthy();
  });
});
