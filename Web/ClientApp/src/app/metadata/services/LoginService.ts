import { Injectable } from "@angular/core";
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from "../models/loginModel";
import { Observable } from "rxjs";
import { map, catchError } from "rxjs/operators";
import { gatewayBaseUri } from "../../../environments/environment";

@Injectable()
export class LoginService {

  public token: string;
  constructor(
    private http: HttpClient,
  ) { }


  public login(loginModel: LoginModel): Observable<any> {
    return this.http.post(gatewayBaseUri + '/api/Login/LoginUser', loginModel)
      .pipe(map((response) => response),
        catchError(() => Observable.throw({ msg: this.handleError(), ngNavigationCancelingError: true })));
  }
    handleError(): any {
        throw new Error("Method not implemented.");
  }  
}
