import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingGridComponent } from './landing-grid.component';

describe('LandingGridComponent', () => {
  let component: LandingGridComponent;
  let fixture: ComponentFixture<LandingGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LandingGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
