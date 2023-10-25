import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardpComponent } from './dashboardp.component';

describe('DashboardpComponent', () => {
  let component: DashboardpComponent;
  let fixture: ComponentFixture<DashboardpComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DashboardpComponent]
    });
    fixture = TestBed.createComponent(DashboardpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
