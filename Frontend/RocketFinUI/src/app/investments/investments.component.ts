import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction, TransactionItem } from '../models/transaction';
import { ActivatedRoute } from '@angular/router';
import { InvestmentService } from '../services/investment.service';
import { Instrument, Result } from '../models/instrument';
import { 
  MatDialog, 
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose, 
} from '@angular/material/dialog';
import { PurchaseSharesComponent } from '../purchase-shares/purchase-shares.component';

export interface DialogData {
    share: string;
    quantity: number;
}
@Component({
  selector: 'app-investments',
  templateUrl: './investments.component.html',
  styleUrls: ['./investments.component.scss']
})
export class InvestmentsComponent {

  share!: string;
  quantity!: number;

  investmentData: Result[]  = [];
  symbol!: string;
  searchTermValue!: any;

  searchFormGroup!: FormGroup;

  constructor(
    private investmentService: InvestmentService, 
    private router: ActivatedRoute, 
    private formBuilder: FormBuilder, 
    public dialog: MatDialog) {
    this.symbol = this.router.snapshot.paramMap.get('symbol') || '';

    this.searchFormGroup = this.formBuilder.group({
      searchTerm: ['', Validators.required],
    });

  }

  displayColumns = ["transactionId", "symbol", "shortName", "longName", "ask", "bid", "regularMarketPrice", "regularMarketDayHigh", "regularMarketDayLow", "regularMarketChange", "regularMarketChangePercent", "regularMarketOpen", "actions"];

  dataSource = new MatTableDataSource(this.investmentData);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  openDialog(symbol: string): void {
    console.log('dhhgf');
    this.share = symbol;
  const dialogRef = this.dialog.open(PurchaseSharesComponent, {
      data: {
        share: this.share,
        quantity: this.quantity
      },
      height: '400px',
      width: '60%',
    });
  }

  onSubmit(){
    if (this.searchFormGroup.valid) {
      this.searchTermValue = this.searchFormGroup.value;
      console.log(this.searchTermValue.searchTerm);

      this.investmentService.getInstrumentBySymbol(this.searchTermValue.searchTerm).subscribe((data: Instrument) => { 
        this.investmentData = data.value.quoteResponse.result;;
  
        this.dataSource = new MatTableDataSource(this.investmentData); 
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
       });
 
    }
  }
}
