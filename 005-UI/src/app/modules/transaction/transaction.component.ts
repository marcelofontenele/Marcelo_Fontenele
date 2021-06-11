import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Transfer } from 'src/app/dto/transfer';
import { TransactionService } from 'src/app/services/transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html'
})
export class TransactionComponent implements OnInit {

    success:boolean;

    form:FormGroup;

    constructor(
        private transactionService: TransactionService,
        private fb:FormBuilder) { 

        this.form = this.fb.group({
            target_bank: ['352'],
            target_branch: ['0001'],
            target_account: ['1', Validators.required],
            
            origin_bank: ['033'],
            origin_branch: ['03312'],
            origin_cpf: ['45358996060', Validators.required],
            amount: ['1000.10', Validators.required],
        });
    }

    ngOnInit(): void {
        
    }

    transfer(): void{

        const val = this.form.value;

        if(this.form.valid){
            this.transactionService.transfer(
                {
                    "event": "TRANSFER",
                    "target": {
                        "bank": val.target_bank, 
                        "branch": val.target_branch, 
                        "account": val.target_account
                    },
                    "origin": {
                        "bank": val.origin_bank, 
                        "branch": val.origin_branch,
                        "cpf": val.origin_cpf
                    },
                    "amount": val.amount
                } as Transfer)
                .subscribe(() => {
                    this.success = true;
                });
        }
  }
}
