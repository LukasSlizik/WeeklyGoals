import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { GoalComponent } from './goal/goal.component';

const routes: Routes = [
  { path: '', component: OverviewComponent },
  { path: 'create/:id', component: GoalComponent, data: {mode: 'edit'} },
  { path: 'create', component: GoalComponent, data: {mode: 'create'} },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
