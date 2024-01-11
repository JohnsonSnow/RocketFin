import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewportfoliotransactionsComponent } from './viewportfoliotransactions.component';

describe('ViewportfoliotransactionsComponent', () => {
  let component: ViewportfoliotransactionsComponent;
  let fixture: ComponentFixture<ViewportfoliotransactionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewportfoliotransactionsComponent]
    });
    fixture = TestBed.createComponent(ViewportfoliotransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
