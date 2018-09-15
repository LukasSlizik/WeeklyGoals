import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ProgtableComponent } from './components/progtable/progtable.component';
import { ProglineComponent } from './components/progline/progline.component';
import { GoalComponent } from './components/goal/goal.component';
import { EditgoalComponent } from './components/edit/editGoal.component';
import { ProgressService } from "./services/progress.service";
import { GoalService } from "./services/goal.service";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ProgtableComponent,
        ProglineComponent,
        GoalComponent,
        EditgoalComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'progtable', pathMatch: 'full' },
            { path: 'progtable', component: ProgtableComponent },
            { path: 'progline', component: ProglineComponent },
            { path: 'goal', component: GoalComponent },
            { path: 'edit', component: EditgoalComponent },
            { path: '**', redirectTo: 'progtable' }
        ])
    ],
    providers: [
        ProgressService,
        GoalService
    ]
})
export class AppModuleShared {
}
