import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {CommonModule} from "@angular/common";
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {ClientComponent} from './clients/clients.component';
import { AddClientComponent } from './addClient/addclient.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ClientComponent,
    AddClientComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    RouterModule.forRoot([
     {path : '', component:ClientComponent},
     {path:'addclient',component:AddClientComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
