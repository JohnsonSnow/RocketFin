import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortfoliosComponent } from './portfolios.component';
import { ViewportfoliotransactionsComponent } from './viewportfoliotransactions/viewportfoliotransactions.component';

const routes: Routes = [
  { path: '', component: PortfoliosComponent },
  { path: 'portfolio/viewportfoliotransactions/:symbol', component: ViewportfoliotransactionsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortfoliosRoutingModule { }
