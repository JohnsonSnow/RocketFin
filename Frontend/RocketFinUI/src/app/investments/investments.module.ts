import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvestmentsRoutingModule } from './investments-routing.module';
import { InvestmentsComponent } from './investments.component';
import { MatCardModule } from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import { MatDialogModule } from "@angular/material/dialog";
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { PurchaseSharesComponent } from '../purchase-shares/purchase-shares.component';
@NgModule({
  declarations: [
    InvestmentsComponent,
    PurchaseSharesComponent
  ],
  imports: [
    CommonModule,
    InvestmentsRoutingModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    FormsModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatButtonModule,
    RouterModule,
    ReactiveFormsModule,
    MatIconModule,
    //MatDialogModule,
    MatSnackBarModule
  ]
})
export class InvestmentsModule { }
