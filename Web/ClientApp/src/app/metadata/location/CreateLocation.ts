import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { LocationService } from "../services/LocationService";
import { Route, Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { LocationModel } from "../models/Locationmodel";
import { SharedService } from "../services/SharedService";
import { publish } from "rxjs/operators";
import { DepartmentModel } from "../models/departmentModel";

@Component({
  selector: 'createLocation',
  templateUrl: './CreateLocation.html'
})

export class CreateLocation implements OnInit {

  public createLocationForm: FormGroup;
  public departmentDetails: DepartmentModel[];
  public isDepartmentData: boolean;
  public title: string = 'Create Location';
  public buttonName: string = 'Create';
  constructor(
    private fb: FormBuilder,
    private locationService: LocationService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private sharedService: SharedService
  ) { }

  ngOnInit() {
    this.createLocationForm = this.fb.group({
      locationId: [''],
      name: [''],
      description: [''],
    });
    if (this.sharedService.sharingData.locationId !== 0) {
      this.activatedRoute.data.subscribe((res) => {
        if (res) {
          this.createLocationForm.controls['locationId'].setValue(res.LocationOpen.locationId);
          this.createLocationForm.controls['name'].setValue(res.LocationOpen.name);
          this.createLocationForm.controls['description'].setValue(res.LocationOpen.description);
          this.departmentDetails = res.LocationOpen.departmentModel;
          this.isDepartmentData = true;
          this.title = 'Update Location';
          this.buttonName = 'Save';
        }
      });
    }

    this.createLocationForm.controls['name'].setValidators([Validators.required]);
    this.createLocationForm.controls['description'].setValidators([Validators.required]);
  }

  public CreateLocation() {
    if (this.createLocationForm.valid) {
      let locationModel = new LocationModel();
      locationModel.locationId = this.createLocationForm.controls['locationId'].value !== "" ? this.createLocationForm.controls['locationId'].value : 0;
      locationModel.name = this.createLocationForm.controls['name'].value;
      locationModel.description = this.createLocationForm.controls['description'].value;
      this.locationService.submitLocation(locationModel).subscribe((res) => {
        this.router.navigate(['/locationLanding']);
      })
    }
    else {
      Object.keys(this.createLocationForm.controls).map(
        controlName => this.createLocationForm.controls[controlName]).forEach(
          control => {
            control.markAsTouched();
          });
    }
  }

  public editDepartment(departmentId: number) {
    this.sharedService.sharingData.departmentId = departmentId;
    this.router.navigate(['/editdepartment']);
  }
}
