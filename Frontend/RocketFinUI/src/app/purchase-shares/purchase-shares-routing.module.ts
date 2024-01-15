import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PurchaseSharesComponent } from './purchase-shares.component';

const routes: Routes = [{ path: '', component: PurchaseSharesComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseSharesRoutingModule { }
