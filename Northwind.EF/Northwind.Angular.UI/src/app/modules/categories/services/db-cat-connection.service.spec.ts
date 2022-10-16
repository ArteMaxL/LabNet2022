import { TestBed } from '@angular/core/testing';

import { DbCatConnectionService } from './db-cat-connection.service';

describe('DbCatConnectionService', () => {
  let service: DbCatConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DbCatConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
