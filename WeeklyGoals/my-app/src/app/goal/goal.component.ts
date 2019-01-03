import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css'],
})
export class GoalComponent implements OnInit {
  name: string;
  description: string;
  stepSize: number;
  unit: string;
  weeklyTarget: number;
  factor: number;
  startingDate: string;

  constructor(private _dataSvc: DataService) { }

  ngOnInit(): void {
    // this.startingDate = ProgressHelper.convertDateToHtmlInputFormat(new Date());
  }

  public createGoal() {
    // var parsedDate = ProgressHelper.parseHtmlWeek(this.startingDate);
    // var goal = new Goal(
    //   -1,
    //   this.name,
    //   this.description,
    //   this.stepSize,
    //   this.unit,
    //   this.weeklyTarget,
    //   this.factor,
    //   parsedDate.year,
    //   parsedDate.week)
    // this._dataSvc.createNewGoal(goal);
  }

  onName() {
    console.log('name changed');
  }
}
