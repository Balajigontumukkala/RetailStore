import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { DataFilterService } from "./DataFilterService";

@Injectable()
export class GetLocationResolver implements Resolve<any> {
  constructor(private service: DataFilterService) { }

  public resolve(): Observable<any> {
    return this.service.getLocation();
  }
}

