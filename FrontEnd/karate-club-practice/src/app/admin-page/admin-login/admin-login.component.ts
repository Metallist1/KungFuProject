import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../_helperServices/auth.service';
declare var VANTA: any;


@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.scss']
})
export class AdminLoginComponent implements OnInit    {
  loginForm: FormGroup;
  submitted = false;
  loading = false;
  generalErrorMessage = '';

  alertSuccess = false;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private authenticationService: AuthenticationService) {}

  ngOnInit() {
    VANTA.NET({
      el: '#backgroundContainer',
      color: 0x251a7d,
      points: 14.00,
      spacing: 16.00
    });
    //  Initialize the form group
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // reset login status
    this.authenticationService.logout();

  }

  // Getters for easy access to form fields
  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.username.value, this.password.value)
      .subscribe(
        success => {
          this.router.navigate(['/AdminMain']);
        },
        error => {
          this.generalErrorMessage = 'This User does not exist';
          this.alertSuccess = true;
          this.loading = false;
        });
  }
}
