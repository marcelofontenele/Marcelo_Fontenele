import { TestBed } from '@angular/core/testing';

import { InvestimentsService } from './investiments.service';

describe('InvestimentsService', () => {
  let service: InvestimentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestimentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
