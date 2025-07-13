import { TestBed } from '@angular/core/testing';

import { AdministrativoService } from './administrativo.service';

describe('AdministrativoService', () => {
  let service: AdministrativoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdministrativoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
