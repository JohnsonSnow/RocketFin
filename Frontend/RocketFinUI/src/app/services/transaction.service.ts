import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Transaction } from '../models/transaction';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private baseAddress = 'https://localhost:5201';
  constructor(private httpClient: HttpClient) { }

  getAllTransactions(): Observable<Transaction> {
    const url = `${this.baseAddress}/api/Transaction/GetAllTransactions`;
    return this.httpClient.get<Transaction>(url);
  }

  getAllTransactionsBySymbol(name: string): Observable<Transaction> {
    const url = `${this.baseAddress}/api/Transaction/GetAllTransactions?symbol=${name}`;
    return this.httpClient.get<Transaction>(url);
   }

   purchaseShares(data: any): Observable<any> {
    const url = `${this.baseAddress}/api/Transaction/PurchaseShares`;

    return this.httpClient.post<any>(url, data);
   }
}
