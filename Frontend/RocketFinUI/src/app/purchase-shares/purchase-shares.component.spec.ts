import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseSharesComponent } from './purchase-shares.component';

describe('PurchaseSharesComponent', () => {
  let component: PurchaseSharesComponent;
  let fixture: ComponentFixture<PurchaseSharesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseSharesComponent]
    });
    fixture = TestBed.createComponent(PurchaseSharesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
