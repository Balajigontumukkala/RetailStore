import { Injectable } from "@angular/core";
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { SharedService } from "./SharedService";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { gatewayBaseUri } from '../../../environments/environment';
import { LocationModel } from "../models/Locationmodel";

@Injectable()
export class LocationService {
  constructor(
    private http: HttpClient,
    private sharedService: SharedService,
  ) { }

  public locationList(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Location/ListLocation')
      .pipe(map((response) => response), catchError(() => Observable.throw(
        { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public submitLocation(locationModel: LocationModel): Observable<any> {
    return this.http.post(gatewayBaseUri + '/api/Location/SubmitLocation', locationModel)
      .pipe(map((response) => response),
        catchError(() => Observable.throw({ msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  public OpenLocation(): Observable<any> {
    return this.http.get(gatewayBaseUri + '/api/Location/OpenLocation?locationId=' + this.sharedService.sharingData.locationId)
      .pipe(map((response) => response), catchError(() => Observable.throw(
      { msg: this.handleError(), ngNavigationCancelingError: true })));
  }

  handleError(): any {
    throw new Error("Method not implemented.");
  }
}
