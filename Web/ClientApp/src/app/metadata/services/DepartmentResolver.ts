import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { LocationService } from "./LocationService";
import { DepartmentModel } from "../models/departmentModel";
import { DepartmentService } from "./departmentService";

@Injectable()
export class DepartmentListResolver implements Resolve<DepartmentModel> {
  constructor(private service: DepartmentService) { }

  public resolve(): Observable<DepartmentModel> {
    return this.service.ListDepartment();
  }
}

@Injectable()
export class DepartmentOpenResolver implements Resolve<DepartmentModel> {
  constructor(private service: DepartmentService) { }

  public resolve(): Observable<DepartmentModel> {
    return this.service.OpenDepartment();
  }
}
