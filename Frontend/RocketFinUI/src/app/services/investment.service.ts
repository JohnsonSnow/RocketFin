import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Instrument } from '../models/instrument';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  private baseAddress = 'https://localhost:55867';
  constructor(private httpClient: HttpClient) { }

  getInstrumentBySymbol(name: string): Observable<Instrument> {
    const url = `${this.baseAddress}/api/Instrument/${name}`;
    return this.httpClient.get<Instrument>(url);
  }
}
