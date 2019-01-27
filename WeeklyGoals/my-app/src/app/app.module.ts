import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { DataService } from './data.service';
import { OverviewComponent } from './overview/overview.component';
import { GoalComponent } from './goal/goal.component';
import { KeyValuePairs } from './models/EnumToArrayPipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    OverviewComponent,
    GoalComponent,
    KeyValuePairs
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
