import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ModalModule } from './_modal';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { HeaderComponent } from './header/header.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { InfoWindowComponent } from './info-window/info-window.component'
import { ContestsComponent } from "./contests/contests.component";
import { AddContestsComponent } from "./contests/addContest/add-contest.component";
import { ContestDetailsComponent } from "./contests/contestDetails/contest-details.component";
import { AddWorksComponent } from "./contests/addWork/add-work.component";
import { MarkWorksComponent } from "./contests/markWork/mark-work.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ContestsComponent,
    FetchDataComponent,
    HeaderComponent,
    ContestDetailsComponent,
    MainComponent,
    FooterComponent,
    InfoWindowComponent,
    AddContestsComponent,
    AddWorksComponent,
    MarkWorksComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ModalModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'contests', component: ContestsComponent },
      { path: 'contest/:id', component: ContestDetailsComponent },
      { path: 'contest/mark/:id', component: MarkWorksComponent },
      { path: 'info', component: InfoWindowComponent },
      //{ path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
