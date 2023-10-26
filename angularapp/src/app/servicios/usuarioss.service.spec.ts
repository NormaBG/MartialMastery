import { TestBed } from '@angular/core/testing';

import { UsuariossService } from './usuarioss.service';

describe('UsuariossService', () => {
  let service: UsuariossService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UsuariossService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
