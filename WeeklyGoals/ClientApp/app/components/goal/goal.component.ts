import { ProgressService } from "../../services/progress.service";
import { Component } from "@angular/core";

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
}