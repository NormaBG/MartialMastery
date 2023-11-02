import { TestBed } from '@angular/core/testing';

import { ObtenerorganizacionService } from './obtenerorganizacion.service';

describe('ObtenerorganizacionService', () => {
  let service: ObtenerorganizacionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ObtenerorganizacionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
