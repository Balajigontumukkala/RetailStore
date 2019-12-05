import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { LocationModel } from "../metadata/models/Locationmodel";
import { DataFilterService } from "./services/DataFilterService";
import { DepartmentModel } from "../metadata/models/departmentModel";
import { SubcategoryModel } from "../metadata/models/SubcategoryModel";
import { CategoryModel } from "../metadata/models/categoryModel";
import { FormBuilder, FormGroup } from "@angular/forms";
import { SkuDetailsModel } from "../metadata/models/SkuDetailsModel";

@Component({
  selector: 'datafilter',
  templateUrl: './DataFilter.html'
})

export class DataFilter implements OnInit {
  public locationData: LocationModel[];
  public departmentData: DepartmentModel[];
  public categoryData: CategoryModel[];
  public subCategoryData: SubcategoryModel[];
  public filterForm: FormGroup;
  public skuDetailsModel: SkuDetailsModel[];
  public isSearch: boolean;
  constructor(
    private activatedRoute: ActivatedRoute,
    private dataFilterService: DataFilterService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.filterForm = this.fb.group({
      locationId: [''],
      departmentId: [''],
      categoryId: [''],
      subCategoryId: [''],
    })
    this.activatedRoute.data.subscribe((res) => {
      this.locationData = res.GetLocation;
    });
  }

  public filterDepartment(locationId: number) {
    if (locationId > 0) {
      this.dataFilterService.getDepartment(locationId).subscribe((res) => {
        this.departmentData = res;
      });
    }
  }

  public filterCategory(departmentId: number) {
    if (departmentId > 0) {
      this.dataFilterService.getCategory(departmentId).subscribe((res) => {
        this.categoryData = res;
      });
    }
  }

  public filtersubCategory(categoryId: number) {
    if (categoryId > 0) {
      this.dataFilterService.getSubcategory(categoryId).subscribe((res) => {
        this.subCategoryData = res;
      });
    }
  }

  public searchData() {
    if (this.filterForm.valid) {
      this.dataFilterService.getData(this.filterForm.value).subscribe((res) => {
        this.skuDetailsModel = res;
        this.isSearch = true;
      })
    }
  }
}
