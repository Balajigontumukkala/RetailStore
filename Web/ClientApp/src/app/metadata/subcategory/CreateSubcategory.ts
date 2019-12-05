import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute} from "@angular/router";
import { SharedService } from "../services/SharedService";
import { SubcategoryModel } from "../models/SubcategoryModel";
import { SubcategoryService } from "../services/SubcategoryService";

@Component({
  selector: 'createSubcategory',
  templateUrl: './CreateSubcategory.html'
})

export class CreateSubcategory implements OnInit {

  public createSubcategoryForm: FormGroup;
  public title: string = 'Create Subcategory';
  public buttonName: string = 'Create';
  constructor(
    private fb: FormBuilder,
    private subcategoryService: SubcategoryService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private sharedService: SharedService
  ) { }

  ngOnInit() {
    this.createSubcategoryForm = this.fb.group({
      subcategoryId:[''],
      categoryId: [''],
      name: [''],
      description: [''],
    });
    if (this.sharedService.sharingData.subcategoryId !== 0) {
      this.activatedRoute.data.subscribe((res) => {
        if (res) {
          this.createSubcategoryForm.controls['subcategoryId'].setValue(res.SubcategoryOpen.subcategoryId);
          this.createSubcategoryForm.controls['categoryId'].setValue(res.SubcategoryOpen.categoryId);
          this.createSubcategoryForm.controls['name'].setValue(res.SubcategoryOpen.name);
          this.createSubcategoryForm.controls['description'].setValue(res.SubcategoryOpen.description);
          this.title = 'Update Subcategory';
          this.buttonName = 'Save';
        }
      });
    }

    this.createSubcategoryForm.controls['name'].setValidators([Validators.required]);
    this.createSubcategoryForm.controls['description'].setValidators([Validators.required]);
  }

  public CreateSubcategory() {
    if (this.createSubcategoryForm.valid) {
      let subcategoryModel = new SubcategoryModel()
      subcategoryModel.subcategoryId = this.createSubcategoryForm.controls['subcategoryId'].value !== "" ? this.createSubcategoryForm.controls['subcategoryId'].value : 0;
      subcategoryModel.categoryId = this.sharedService.sharingData.categoryId;
      subcategoryModel.name = this.createSubcategoryForm.controls['name'].value;
      subcategoryModel.description = this.createSubcategoryForm.controls['description'].value;
      this.subcategoryService.submitSubcategory(subcategoryModel).subscribe((res) => {
        this.router.navigate(['/editcategory']);
      })
    }
    else {
      Object.keys(this.createSubcategoryForm.controls).map(
        controlName => this.createSubcategoryForm.controls[controlName]).forEach(
          control => {
            control.markAsTouched();
          });
    }
  }

  public editSubcategory(categoryId: number) {
    this.sharedService.sharingData.categoryId = categoryId;
    this.router.navigate(['/editsubcategory']);
  }
}
