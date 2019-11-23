import { TestBed } from '@angular/core/testing';

import { ItemFormatterService } from './item-formatter.service';

describe('ItemFormatterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ItemFormatterService = TestBed.get(ItemFormatterService);
    expect(service).toBeTruthy();
  });
});
