import { Injectable } from "@angular/core";
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { SharedService } from "./SharedService";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { gatewayBaseUri } from '../../../environments/environment';
import { CategoryModel } from "../models/CategoryModel";

@Injectable()
export class CategoryService {
  constructor(
    private http: HttpClient,
    private sharedService: SharedService,
  ) { }

  public ListCategory(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Category/ListCategory')
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public submitCategory(categoryModel: CategoryModel): Observable<any> {
    return this.http.post(gatewayBaseUri + '/api/Category/SubmitCategory', categoryModel)
      .pipe(map((response) => response),
        catchError(() => Observable.throw({ msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public OpenCategory(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Category/OpenCategory?CategoryId=' + this.sharedService.sharingData.categoryId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
      { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  handleError(): any {
    throw new Error("Method not implemented.");
  }
}
