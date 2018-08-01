import { ProgressService } from "../../services/progress.service";
import { Component } from "@angular/core";
import { Goal } from "../../models/Goal"

@Component({
    selector: 'goal',
    templateUrl: './goal.component.html',
    styleUrls: ['./goal.component.css']
})
export class GoalComponent {
    name: string;
    description: string;
    stepSize: number;
    unit: string;
    weeklyTarget: number;
    factor: number;

    constructor(private _progressSvc: ProgressService) { }

    ngOnInit(): void {

    }

    public createGoal() {
        var goal = new Goal(this.name, this.description, this.stepSize, this.unit, this.weeklyTarget, this.factor)
        this._progressSvc.createNewGoal(goal);
    }
}