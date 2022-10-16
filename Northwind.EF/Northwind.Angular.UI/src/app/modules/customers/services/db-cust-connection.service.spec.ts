import { TestBed } from '@angular/core/testing';

import { DbCustConnectionService } from './db-cust-connection.service';

describe('DbCustConnectionService', () => {
  let service: DbCustConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DbCustConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
