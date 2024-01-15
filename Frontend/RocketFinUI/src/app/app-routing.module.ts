import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./portfolios/portfolios.module').then(m => m.PortfoliosModule) }, 
  { path: 'investments', loadChildren: () => import('./investments/investments.module').then(m => m.InvestmentsModule) }, 
  { path: 'transactions', loadChildren: () => import('./transactions/transactions.module').then(m => m.TransactionsModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
