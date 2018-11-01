import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProgtableComponent } from './progtable/progtable.component';

const routes: Routes = [
  { path: 'progtable', component: ProgtableComponent }
];

@NgModule({
  declarations: [ProgtableComponent],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
