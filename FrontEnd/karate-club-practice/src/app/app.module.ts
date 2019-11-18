import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { JwtInterceptor } from './_helperServices/jwt.interceptor';
import {  ErrorInterceptor } from './_helperServices/error.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdminLoginComponent } from './admin-page/admin-login/admin-login.component';
import { AdminEditComponent } from './admin-page/admin-edit/admin-edit.component';
import { AdminCreateComponent } from './admin-page/admin-create/admin-create.component';
import { AdminListUsersComponent } from './admin-page/admin-list-users/admin-list-users.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { MainViewComponent } from './main-view/main-view.component';
import { AdminFooterComponent } from './admin-page/admin-components/admin-footer/admin-footer.component';
import { AdminHeaderComponent } from './admin-page/admin-components/admin-header/admin-header.component';
import { NgbdSortableDirective } from './admin-page/admin-list-users/admin-list-users.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AdminLoginComponent,
    AdminEditComponent,
    AdminCreateComponent,
    AdminListUsersComponent,
    AdminPageComponent,
    MainViewComponent,
    AdminFooterComponent,
    AdminHeaderComponent,
    NgbdSortableDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
