import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { LoginService } from "../metadata/services/LoginService";
import { Router } from "@angular/router";

@Component({
  selector: 'login',
  templateUrl: './LoginComponent.html'
})

export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public isValid: boolean;
  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private route: Router) {
  }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [''],
      password : ['']
    })
  }

  public login() {
    this.loginService.login(this.loginForm.value).subscribe((res) => {
      if (res.token !== null) {
        this.loginService.token = res.token;
        this.route.navigate(['/locationLanding']);
      }
      else {
        this.isValid = true;
      }
    })
  }
}
