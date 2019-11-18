import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../_helperServices/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.scss']
})
export class AdminHeaderComponent implements OnInit {

  constructor(private router: Router,
              private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

  logOut(){
    this.authenticationService.logout();
    this.router.navigate(['/']);
  }
}
