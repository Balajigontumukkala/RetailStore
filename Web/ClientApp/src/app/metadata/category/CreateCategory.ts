import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { SharedService } from "../services/SharedService";
import { CategoryService } from "../services/CategoryService";
import { CategoryModel } from "../models/CategoryModel";

@Component({
  selector: 'createCategory',
  templateUrl: './CreateCategory.html'
})

export class CreateCategory implements OnInit {

  public createCategoryForm: FormGroup;
  public categoryDetails: CategoryModel[];
  public isCategoryData: boolean;
  public title: string = 'Create Category';
  public buttonName: string = 'Create';
  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private sharedService: SharedService
  ) { }

  ngOnInit() {
    this.createCategoryForm = this.fb.group({
      departmentId:[''],
      categoryId: [''],
      name: [''],
      description: [''],
    });
    if (this.sharedService.sharingData.categoryId !== 0) {
      this.activatedRoute.data.subscribe((res) => {
        if (res) {
          this.createCategoryForm.controls['categoryId'].setValue(res.CategoryOpen.categoryId);
          this.createCategoryForm.controls['departmentId'].setValue(res.CategoryOpen.departmentId);
          this.createCategoryForm.controls['name'].setValue(res.CategoryOpen.name);
          this.createCategoryForm.controls['description'].setValue(res.CategoryOpen.description);
          this.categoryDetails = res.CategoryOpen.subcategoryModel;
          this.isCategoryData = true;
          this.title = 'Update Category';
          this.buttonName = 'Save';
        }
      });
    }

    this.createCategoryForm.controls['name'].setValidators([Validators.required]);
    this.createCategoryForm.controls['description'].setValidators([Validators.required]);
  }

  public createCategory() {
    if (this.createCategoryForm.valid) {
      let categoryModel = new CategoryModel();
      categoryModel.categoryId = this.createCategoryForm.controls['categoryId'].value !== "" ? this.createCategoryForm.controls['categoryId'].value : 0;
      categoryModel.departmentId = this.sharedService.sharingData.departmentId;
      categoryModel.name = this.createCategoryForm.controls['name'].value;
      categoryModel.description = this.createCategoryForm.controls['description'].value;
      this.categoryService.submitCategory(categoryModel).subscribe((res) => {
        this.router.navigate(['/editdepartment']);
      })
    }
    else {
      Object.keys(this.createCategoryForm.controls).map(
        controlName => this.createCategoryForm.controls[controlName]).forEach(
          control => {
            control.markAsTouched();
          });
    }
  } 

  public editSubcategoty(subcategoryId: number) {
    this.sharedService.sharingData.subcategoryId = subcategoryId;
    this.router.navigate(['/editsubcategory']);
  }
}
