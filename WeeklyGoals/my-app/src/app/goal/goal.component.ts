import { Component, OnInit } from '@angular/core';
import { ProgressService } from "../services/progress.service";
import { Goal } from "../models/Goal";
import { ProgressHelper } from "../helpers/progress-helper";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css'],
})
export class GoalComponent {
  name: string;
  description: string;
  stepSize: number;
  unit: string;
  weeklyTarget: number;
  factor: number;
  startingDate: string;

  constructor(private _progressSvc: ProgressService) { }

  ngOnInit(): void {
    this.startingDate = ProgressHelper.convertDateToHtmlInputFormat(new Date());
  }

  public createGoal() {
    var parsedDate = ProgressHelper.parseHtmlWeek(this.startingDate);
    var goal = new Goal(
      -1,
      this.name,
      this.description,
      this.stepSize,
      this.unit,
      this.weeklyTarget,
      this.factor,
      parsedDate.year,
      parsedDate.week)
    this._progressSvc.createNewGoal(goal);
  }

  onName() {
    console.log('name changed');
  }
}
