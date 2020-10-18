import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { UserCredentials } from './user-credentials.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  createUser(creds: UserCredentials): Observable<boolean> {
    return this.http.post<boolean>("api/account/createUser", creds);
  }
}
