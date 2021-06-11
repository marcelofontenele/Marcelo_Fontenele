import { AuthGuard } from './services/auth-guard';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: '',
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule) 
  },
  { 
    path: 'login',
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule) 
  },
  { 
    canActivate: [AuthGuard], 
    path: 'user', loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule) 
  },
  { 
    path: 'transaction', loadChildren: () => import('./modules/transaction/transaction.module').then(m => m.TransactionModule) 
  },
  { 
    canActivate: [AuthGuard],
    path: 'trends', loadChildren: () => import('./modules/trends/trends.module').then(m => m.TrendsModule) 
  },
  { 
    canActivate: [AuthGuard],
    path: 'order', loadChildren: () => import('./modules/order/order.module').then(m => m.OrderModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }