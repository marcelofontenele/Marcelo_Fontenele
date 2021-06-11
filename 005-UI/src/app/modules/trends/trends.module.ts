import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TrendsRoutingModule } from './trends-routing.module';
import { TrendsComponent } from './trends.component';
import { ComponentsModule } from 'src/app/components/components.module';


@NgModule({
  declarations: [
    TrendsComponent
  ],
  imports: [
    ComponentsModule,
    CommonModule,
    TrendsRoutingModule
  ]
})
export class TrendsModule { }
