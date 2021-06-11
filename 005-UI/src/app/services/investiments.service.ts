import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Stock } from '../dto/stock';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvestimentsService {

    constructor(
        private http: HttpClient) { }

    public getTrends() : Observable<Stock[]>{
        return this.http.get<Stock[]>(`${environment.ms_investiments_api}/v1/investiments/trends`);
    }

    public postOrder(order: Stock) : Observable<any>{
        return this.http.post<any>(
          `${environment.ms_investiments_api}/v1/investiments/order`,
          JSON.stringify(order)
        );
    }
}
