import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { SharedService } from "./SharedService";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { gatewayBaseUri } from '../../../environments/environment';
import { SubcategoryModel } from "../models/SubcategoryModel";

@Injectable()
export class SubcategoryService {
  constructor(
    private http: HttpClient,
    private sharedService: SharedService,
  ) { }

  public ListSubcategory(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Subcategory/ListSubcategory')
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public submitSubcategory(subcategoryModel: SubcategoryModel): Observable<any> {
    return this.http.post(gatewayBaseUri + '/api/Subcategory/SubmitSubcategory', subcategoryModel)
      .pipe(map((response) => response),
        catchError(() => Observable.throw({ msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public OpenSubcategory(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Subcategory/OpenSubcategory?SubcategoryId=' + this.sharedService.sharingData.subcategoryId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
      { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  handleError(): any {
    throw new Error("Method not implemented.");
  }
}
