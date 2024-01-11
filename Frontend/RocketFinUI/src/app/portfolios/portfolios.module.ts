import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PortfoliosRoutingModule } from './portfolios-routing.module';
import { PortfoliosComponent } from './portfolios.component';
import { MatCardModule } from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { ViewportfoliotransactionsComponent } from './viewportfoliotransactions/viewportfoliotransactions.component';

@NgModule({
  declarations: [
    PortfoliosComponent,
    ViewportfoliotransactionsComponent
  ],
  imports: [
    CommonModule,
    PortfoliosRoutingModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule
  ]
})
export class PortfoliosModule { }
