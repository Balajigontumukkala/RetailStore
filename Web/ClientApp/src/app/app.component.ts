import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './metadata/services/LoginService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(
    private route: Router,
    private loginService: LoginService
  ) { }
  ngOnInit() {
    if (this.loginService.token == undefined) {
      this.route.navigate(['/login']);
    }
  }
}
