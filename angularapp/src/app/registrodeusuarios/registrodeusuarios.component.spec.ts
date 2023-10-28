import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrodeusuariosComponent } from './registrodeusuarios.component';

describe('RegistrodeusuariosComponent', () => {
  let component: RegistrodeusuariosComponent;
  let fixture: ComponentFixture<RegistrodeusuariosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RegistrodeusuariosComponent]
    });
    fixture = TestBed.createComponent(RegistrodeusuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
