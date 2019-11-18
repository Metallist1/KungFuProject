import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { User } from '../models/user';
import { AuthenticationService } from '../../_helperServices/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserListService {

  constructor() { }
}


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    Authorization: 'my-auth-token'
  })
};

@Injectable
({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  getItems(): Observable<User[]> {
    // get users from api
    return this.http.get<User[]>(environment.apiUrl + '/api/Login', httpOptions);
  }
}
