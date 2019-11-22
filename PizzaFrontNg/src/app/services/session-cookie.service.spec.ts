import { TestBed } from '@angular/core/testing';

import { SessionCookieService } from './session-cookie.service';

describe('SessionCookieService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SessionCookieService = TestBed.get(SessionCookieService);
    expect(service).toBeTruthy();
  });
});
