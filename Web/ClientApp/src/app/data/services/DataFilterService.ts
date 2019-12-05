import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { gatewayBaseUri } from '../../../environments/environment';
import { SkuDetailsModel } from "src/app/metadata/models/SkuDetailsModel";

@Injectable()
export class DataFilterService {
  constructor(
    private http: HttpClient
  ) { }

  public getLocation(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Location/ListLocation')
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public getDepartment(locationId: number): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Department/ListDepartmentBasedonLocation?locationId=' + locationId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public getCategory(departmentId: number): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Category/ListCategoryBasedonDepartment?departmentId=' + departmentId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public getSubcategory(categoryId: number): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Subcategory/ListSubcategoryBasedonCategory?categoryId=' + categoryId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public getData(searchModel: SkuDetailsModel): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/SkuDetails/ListSkuDetails?locationId=' + searchModel.locationId + '&departmentId=' + searchModel.departmentId +
      '&categoryId=' + searchModel.categoryId + '&subCategoryId=' + searchModel.subCategoryId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  handleError(): any {
    throw new Error("Method not implemented.");
  }
}
