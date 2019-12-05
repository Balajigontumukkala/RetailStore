import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { CategoryModel } from "../models/CategoryModel";
import { CategoryService } from "./CategoryService";

@Injectable()
export class CategoryListResolver implements Resolve<CategoryModel> {
  constructor(private service: CategoryService) { }

  public resolve(): Observable<CategoryModel> {
    return this.service.ListCategory();
  }
}

@Injectable()
export class CategoryOpenResolver implements Resolve<CategoryModel> {
  constructor(private service: CategoryService) { }

  public resolve(): Observable<CategoryModel> {
    return this.service.OpenCategory();
  }
}
