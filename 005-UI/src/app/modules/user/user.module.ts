import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { ComponentsModule } from 'src/app/components/components.module';
import { UserService } from 'src/app/services/user.service';

@NgModule({
  declarations: [
    UserComponent
  ],
  imports: [
    ComponentsModule,
    CommonModule,
    UserRoutingModule
  ],
  providers: [
    UserService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class UserModule { }
