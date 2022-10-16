import { TestBed } from '@angular/core/testing';

import { DbFkConnectionService } from './db-fk-connection.service';

describe('DbFkConnectionService', () => {
  let service: DbFkConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DbFkConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
