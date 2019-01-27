import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { GoalComponent } from './goal/goal.component';
import { Mode } from './models/Mode';

const routes: Routes = [
  { path: '', component: OverviewComponent },
  { path: 'create/:id', component: GoalComponent, data: { mode: Mode.edit } },
  { path: 'create', component: GoalComponent, data: { mode: Mode.create } },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
