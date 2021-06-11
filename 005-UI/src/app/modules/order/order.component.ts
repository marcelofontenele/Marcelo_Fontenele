import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Stock } from 'src/app/dto/stock';
import { InvestimentsService } from 'src/app/services/investiments.service';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {

    success: boolean;
    error: string;
    form:FormGroup;

    constructor(
      private investimentsService: InvestimentsService,
      private fb:FormBuilder) {

        this.form = this.fb.group({
          symbol: ['', Validators.required],
          amount: ['', Validators.required],
      });
    }

    ngOnInit(): void { }

    emitir() {

      const val = this.form.value;

        if(this.form.valid) {

            this.investimentsService.postOrder(
                {
                    symbol: val.symbol,
                    amount: parseFloat(val.amount)
                } as Stock
            ).pipe(
                catchError(error => {
                    this.error = `Erro: ${error.error}`;
                    return of(this.error);
                })
            ).subscribe(() => {
                this.success = !this.error;
            });
        }
    }
}
