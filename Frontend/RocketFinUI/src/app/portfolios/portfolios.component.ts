import { Component, ViewChild } from '@angular/core';
import { Item, PorfilioItem, Portfolio } from '../models/portfolio';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PortfolioService } from '../services/portfolio.service';

const TABLE_DATA: Item[] = [
  {
    "symbol": "AAPL",
    "costBasis": 1516970,
    "marketValue": 186.19,
    "unrealizedReturnRate": -99.98772619102553,
    "unrealizedProfitLoss": -1516783.81
  },
  {
    "symbol": "MSFT",
    "costBasis": 1516970,
    "marketValue": 568.96,
    "unrealizedReturnRate": -99.96249365511513,
    "unrealizedProfitLoss": -1516401.04
  }
];

@Component({
  selector: 'app-portfolios',
  templateUrl: './portfolios.component.html',
  styleUrls: ['./portfolios.component.scss']
})
export class PortfoliosComponent {

  portfolios: PorfilioItem[] = [];

  constructor(private portfolioService: PortfolioService) {
    this.portfolioService.getPortfolios().subscribe((data: Portfolio) => {
      this.portfolios = data.value.items;
      console.log(this.portfolios);
      this.dataSource = new MatTableDataSource(this.portfolios); 
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  };

  displayColumns = ["symbol", "costBasis", "marketValue", "unrealizedReturnRate", "unrealizedProfitLoss", "actions"];

  dataSource = new MatTableDataSource(this.portfolios);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


}
