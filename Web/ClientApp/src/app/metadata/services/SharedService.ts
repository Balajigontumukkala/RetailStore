import { Injectable } from "@angular/core";

@Injectable()
export class SharedService {
  sharingData: MyData = {
    locationId: 0,
    departmentId: 0,
    categoryId: 0,
    subcategoryId : 0
  }

  public resetValues() {
    this.sharingData.locationId = 0;
    this.sharingData.departmentId = 0;
    this.sharingData.categoryId = 0,
      this.sharingData.subcategoryId = 0
  }
}

export interface MyData {
  locationId: number;
  departmentId: number;
  categoryId: number;
  subcategoryId: number;
}
