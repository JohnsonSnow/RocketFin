import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Portfolio } from '../models/portfolio';
import { Observable } from 'rxjs';
import { Transaction } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  private baseAddress = 'https://localhost:55867';
  constructor(private httpClient: HttpClient) { }

  getPortfolios(): Observable<Portfolio> {
    const url = `${this.baseAddress}/api/Portfolio/GetPortfolio`;
     return this.httpClient.get<Portfolio>(url);
   }

   getPortfolioTransactionsBySymbol(name: string): Observable<Transaction> {
    const url = `${this.baseAddress}/api/Transaction/GetAllTransactions?symbol=${name}`;
    return this.httpClient.get<Transaction>(url);
   }
}
