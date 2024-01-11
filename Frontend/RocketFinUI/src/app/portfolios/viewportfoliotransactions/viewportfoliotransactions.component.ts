import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Transaction, TransactionItem } from 'src/app/models/transaction';
import { PortfolioService } from 'src/app/services/portfolio.service';

@Component({
  selector: 'app-viewportfoliotransactions',
  templateUrl: './viewportfoliotransactions.component.html',
  styleUrls: ['./viewportfoliotransactions.component.scss']
})
export class ViewportfoliotransactionsComponent {

  portfolioTransaction: TransactionItem[] = [];
  symbol!: string;

  constructor(private portfolioService: PortfolioService, private router: ActivatedRoute){
    this.symbol = this.router.snapshot.paramMap.get('symbol') || '';

    this.portfolioService.getPortfolioTransactionsBySymbol(this.symbol).subscribe((data: Transaction) => { 
      this.portfolioTransaction = data.value.items;

      this.dataSource = new MatTableDataSource(this.portfolioTransaction); 
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
     });
  }

  displayColumns = ["transactionId", "symbol", "shortName", "longName", "ask", "bid", "regularMarketPrice", "regularMarketDayHigh", "regularMarketDayLow", "regularMarketChange", "regularMarketChangePercent", "regularMarketOpen", "quantity", "pricePerShare", "purchaseDateAtUtcNow", "actions"];

  dataSource = new MatTableDataSource(this.portfolioTransaction);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
}
