import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderSidesComponent } from './order-sides.component';

describe('OrderSidesComponent', () => {
  let component: OrderSidesComponent;
  let fixture: ComponentFixture<OrderSidesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderSidesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderSidesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
