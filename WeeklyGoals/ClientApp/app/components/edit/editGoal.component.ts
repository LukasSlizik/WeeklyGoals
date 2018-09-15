import { Component } from "@angular/core";
import { GoalService } from "../../services/goal.service";
import { Goal } from "../../models/Goal";

@Component({
    selector: 'editgoal',
    templateUrl: './editgoal.component.html',
    styleUrls: ['./editgoal.component.css']
})
export class EditgoalComponent {
    private _goals: Goal[];

    constructor(private _goalSvc: GoalService) { }

    ngOnInit(): void {
        this._goalSvc.getAllGoals().subscribe(goals => {
            this._goals = goals;
        });
    }
}