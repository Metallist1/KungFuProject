import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainViewComponent } from './main-view/main-view.component';


import { AdminLoginComponent } from './admin-page/admin-login/admin-login.component';
import { AdminAuthenticationGuard } from './_helperServices/_guard/admin.authentication.guard';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminCreateComponent } from './admin-page/admin-create/admin-create.component';
import { AdminListUsersComponent } from './admin-page/admin-list-users/admin-list-users.component';
import { AdminEditComponent } from './admin-page/admin-edit/admin-edit.component';

const routes: Routes = [{path: 'Admin', component: AdminLoginComponent },
  {path: 'AdminMain', component: AdminPageComponent, canActivate: [AdminAuthenticationGuard]  },
  {path: 'AdminCreate', component: AdminCreateComponent, canActivate: [AdminAuthenticationGuard]  },
  {path: 'AdminEdit', component: AdminEditComponent, canActivate: [AdminAuthenticationGuard]  },
  {path: 'AdminListUsers', component: AdminListUsersComponent, canActivate: [AdminAuthenticationGuard]  },
  {path: '', component: MainViewComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
