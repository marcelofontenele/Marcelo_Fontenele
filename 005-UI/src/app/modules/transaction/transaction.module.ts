import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionComponent } from './transaction.component';
import { ComponentsModule } from 'src/app/components/components.module';
import { TransactionRoutingModule } from './transaction-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TransactionComponent
  ],
  imports: [
    ComponentsModule,
    CommonModule,
    TransactionRoutingModule,
    ReactiveFormsModule
  ]
})
export class TransactionModule { }
