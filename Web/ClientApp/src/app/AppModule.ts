import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LocationLanding } from './metadata/location/locationLanding';
import { LocationListResolver, LocationOpenResolver } from './metadata/services/LocationResolver';
import { LocationService } from './metadata/services/LocationService';
import { SharedService } from './metadata/services/SharedService';
import { CreateLocation } from './metadata/location/CreateLocation';
import { CreateDepartment } from './metadata/department/CreateDepartment';
import { DepartmentService } from './metadata/services/departmentService';
import { DepartmentOpenResolver } from './metadata/services/departmentResolver';
import { CreateCategory } from './metadata/category/CreateCategory';
import { CategoryService } from './metadata/services/CategoryService';
import { CategoryOpenResolver } from './metadata/services/CategoryResolver';
import { CreateSubcategory } from './metadata/subcategory/CreateSubcategory';
import { SubcategoryService } from './metadata/services/SubcategoryService';
import { SubcategoryOpenResolver } from './metadata/services/SubcategoryResolver';
import { DataFilter } from './data/DataFilter';
import { GetLocationResolver } from './data/services/DataFilterResolver';
import { DataFilterService } from './data/services/DataFilterService';
import { LoginComponent } from './login/LoginComponent';
import { LoginService } from './metadata/services/LoginService';
import { NavMenuComponentAfterLogin } from './nav-menu-afterlogin/nav-menu-after.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LocationLanding, CreateLocation, CreateDepartment, CreateCategory, CreateSubcategory,
    DataFilter, LoginComponent,
    NavMenuComponentAfterLogin
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'locationLanding', component: LocationLanding, resolve: { LocationList: LocationListResolver } },
      { path: 'createlocation', component: CreateLocation },
      { path: 'editlocation', component: CreateLocation, resolve: { LocationOpen: LocationOpenResolver } },
      { path: 'createdepartment', component: CreateDepartment },
      { path: 'editdepartment', component: CreateDepartment, resolve: { DepartmentOpen: DepartmentOpenResolver } },
      { path: 'createcategory', component: CreateCategory },
      { path: 'editcategory', component: CreateCategory, resolve: { CategoryOpen: CategoryOpenResolver } },
      { path: 'createsubcategory', component: CreateSubcategory },
      { path: 'editsubcategory', component: CreateSubcategory, resolve: { SubcategoryOpen: SubcategoryOpenResolver } },
      { path: 'data', component: DataFilter, resolve: { GetLocation: GetLocationResolver } }
    ])
  ],
  providers: [
    LocationService,
    LocationListResolver,
    LocationOpenResolver,
    SharedService,
    DepartmentService,
    DepartmentOpenResolver,
    CategoryService,
    CategoryOpenResolver,
    SubcategoryService,
    SubcategoryOpenResolver,
    DataFilterService,
    GetLocationResolver,
    LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
