import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { LocationService } from "../services/LocationService";
import { Route, Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { LocationModel } from "../models/Locationmodel";
import { SharedService } from "../services/SharedService";
import { DepartmentService } from "../services/departmentService";
import { DepartmentModel } from "../models/departmentModel";
import { CategoryModel } from "../models/categoryModel";

@Component({
  selector: 'createDepartment',
  templateUrl: './CreateDepartment.html'
})

export class CreateDepartment implements OnInit {

  public createDepartmentForm: FormGroup;
  public categoryDetails: CategoryModel[];
  public isCategoryData: boolean;
  public title: string = 'Create Department';
  public buttonName: string = 'Create';
  constructor(
    private fb: FormBuilder,
    private departmentService: DepartmentService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private sharedService: SharedService
  ) { }

  ngOnInit() {
    this.createDepartmentForm = this.fb.group({
      departmentId:[''],
      locationId: [''],
      name: [''],
      description: [''],
    });
    if (this.sharedService.sharingData.departmentId !== 0) {
      this.activatedRoute.data.subscribe((res) => {
        if (res) {
          this.createDepartmentForm.controls['departmentId'].setValue(res.DepartmentOpen.departmentId);
          this.createDepartmentForm.controls['locationId'].setValue(res.DepartmentOpen.locationId);
          this.createDepartmentForm.controls['name'].setValue(res.DepartmentOpen.name);
          this.createDepartmentForm.controls['description'].setValue(res.DepartmentOpen.description);
          this.categoryDetails = res.DepartmentOpen.categoryModel;
          this.isCategoryData = true;
          this.title = 'Update Department';
          this.buttonName = 'Save';
        }
      });
    }

    this.createDepartmentForm.controls['name'].setValidators([Validators.required]);
    this.createDepartmentForm.controls['description'].setValidators([Validators.required]);
  }

  public CreateLocation() {
    if (this.createDepartmentForm.valid) {
      let departmentModel = new DepartmentModel();
      departmentModel.departmentId = this.createDepartmentForm.controls['departmentId'].value !== "" ? this.createDepartmentForm.controls['departmentId'].value : 0;
      departmentModel.locationId = this.sharedService.sharingData.locationId;
      departmentModel.name = this.createDepartmentForm.controls['name'].value;
      departmentModel.description = this.createDepartmentForm.controls['description'].value;
      this.departmentService.submitDepartment(departmentModel).subscribe((res) => {
        this.router.navigate(['/editlocation']);
      })
    }
    else {
      Object.keys(this.createDepartmentForm.controls).map(
        controlName => this.createDepartmentForm.controls[controlName]).forEach(
          control => {
            control.markAsTouched();
          });
    }
  }

  public editDepartment(categoryId: number) {
    this.sharedService.sharingData.categoryId = categoryId;
    this.router.navigate(['/editcategory']);
  }
}
