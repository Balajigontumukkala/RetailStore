import { Injectable } from "@angular/core";
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { SharedService } from "./SharedService";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { gatewayBaseUri } from '../../../environments/environment';
import { DepartmentModel } from "../models/departmentModel";

@Injectable()
export class DepartmentService {
  constructor(
    private http: HttpClient,
    private sharedService: SharedService,
  ) { }

  public ListDepartment(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Department/ListDepartment')
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public submitDepartment(departmentModel: DepartmentModel): Observable<any> {
    return this.http.post(gatewayBaseUri + '/api/Department/SubmitDepartment', departmentModel)
      .pipe(map((response) => response),
        catchError(() => Observable.throw({ msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public OpenDepartment(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Department/OpenDepartment?DepartmentId=' + this.sharedService.sharingData.departmentId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
      { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  handleError(): any {
    throw new Error("Method not implemented.");
  }
}
