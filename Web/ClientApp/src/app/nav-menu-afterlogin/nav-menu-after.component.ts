import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../metadata/services/LoginService';

@Component({
  selector: 'app-nav-menu-afterlogin',
  templateUrl: './nav-menu-after.component.html',
  styleUrls: ['./nav-menu-after.component.css']
})
export class NavMenuComponentAfterLogin implements OnInit {
  isExpanded = false;
  constructor(
    private route: Router,
    private loginService: LoginService
  ) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit() {
  }

  public logout() {
    this.loginService.token = "";
    this.route.navigate(['./login']);
  }
}
