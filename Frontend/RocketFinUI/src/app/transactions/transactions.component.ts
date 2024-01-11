import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Transaction, TransactionItem } from '../models/transaction';
import { ActivatedRoute } from '@angular/router';
import { TransactionService } from '../services/transaction.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent {
  allTransaction: TransactionItem[] = [];
  symbol!: string;
  searchTermValue!: any;

  searchFormGroup!: FormGroup;

  constructor(private transactionService: TransactionService, private router: ActivatedRoute, private formBuilder: FormBuilder) {
    this.symbol = this.router.snapshot.paramMap.get('symbol') || '';

    this.searchFormGroup = this.formBuilder.group({
      searchTerm: ['', Validators.required],
      name: ['']
    });

    if (this.searchTermValue?.length > 0) {
      this.transactionService.getAllTransactionsBySymbol(this.searchTermValue).subscribe((data: Transaction) => { 
        this.allTransaction = data.value.items;
  
        this.dataSource = new MatTableDataSource(this.allTransaction); 
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
       });
    }else{
      this.transactionService.getAllTransactions().subscribe((data: Transaction) => { 
        this.allTransaction = data.value.items;
  
        this.dataSource = new MatTableDataSource(this.allTransaction); 
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
       });
    }

    
  }

  displayColumns = ["transactionId", "symbol", "shortName", "longName", "ask", "bid", "regularMarketPrice", "regularMarketDayHigh", "regularMarketDayLow", "regularMarketChange", "regularMarketChangePercent", "regularMarketOpen", "quantity", "pricePerShare", "purchaseDateAtUtcNow", "actions"];

  dataSource = new MatTableDataSource(this.allTransaction);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  onSubmit(){
    if (this.searchFormGroup.valid) {
      this.searchTermValue = this.searchFormGroup.value;
    }
  }
}
