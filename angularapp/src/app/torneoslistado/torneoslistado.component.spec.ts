import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TorneoslistadoComponent } from './torneoslistado.component';

describe('TorneoslistadoComponent', () => {
  let component: TorneoslistadoComponent;
  let fixture: ComponentFixture<TorneoslistadoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TorneoslistadoComponent]
    });
    fixture = TestBed.createComponent(TorneoslistadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
