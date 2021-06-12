import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Transfer } from '../dto/transfer';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(
    private http: HttpClient) { }

  public transfer(transfer: Transfer) : Observable<any>{
    console.log(transfer)
      return this.http.post<any>(
        `${environment.ms_transaction_api}/v1/spb/events`,
        JSON.stringify(transfer)
      );
  }
}
