import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { ProgressService } from './services/progress.service';
import { GoalService } from './services/goal.service';
import { OverviewComponent } from './overview/overview.component';
import { ProgtableComponent } from './progtable/progtable.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    OverviewComponent,
    ProgtableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ProgressService,
    GoalService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
