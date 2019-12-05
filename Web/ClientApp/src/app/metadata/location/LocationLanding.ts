import { Component, OnInit } from "@angular/core";
import { LocationService } from "../services/LocationService";
import { ActivatedRoute, Router } from "@angular/router";
import { SharedService } from "../services/SharedService";

@Component({
  selector: 'locationLanding',
  templateUrl: './LocationLanding.html'
})

export class LocationLanding implements OnInit {

  public locationDetails: any;
  constructor(
    private locationService: LocationService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private sharedService: SharedService
  ) { }

  ngOnInit() {
    this.sharedService.resetValues();
    this.activatedRoute.data.subscribe((res) => {
      this.locationDetails = res.LocationList;
    });
  }

  public editLocation(locationId: number) {
    this.sharedService.sharingData.locationId = locationId;
    this.router.navigate(['/editlocation']);
  }
}
