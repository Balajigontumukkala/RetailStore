import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { SubcategoryModel } from "../models/SubcategoryModel";
import { SubcategoryService } from "./SubcategoryService";

@Injectable()
export class SubcategoryListResolver implements Resolve<SubcategoryModel> {
  constructor(private service: SubcategoryService) { }

  public resolve(): Observable<SubcategoryModel> {
    return this.service.ListSubcategory();
  }
}

@Injectable()
export class SubcategoryOpenResolver implements Resolve<SubcategoryModel> {
  constructor(private service: SubcategoryService) { }

  public resolve(): Observable<SubcategoryModel> {
    return this.service.OpenSubcategory();
  }
}
