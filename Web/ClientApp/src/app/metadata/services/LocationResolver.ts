import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { LocationModel } from "../models/Locationmodel";
import { LocationService } from "./LocationService";

@Injectable()
export class LocationListResolver implements Resolve<any> {
  constructor(private service: LocationService) { }

  public resolve(): Observable<any> {
    return this.service.locationList();
  }
}

@Injectable()
export class LocationOpenResolver implements Resolve<any> {
  constructor(private service: LocationService) { }

  public resolve(): Observable<any> {
    return this.service.OpenLocation();
  }
}
