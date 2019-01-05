import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Goal } from '../models/Goal';
import { Unit } from '../models/units';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css'],
})
export class GoalComponent implements OnInit {
  submitted = false;
  model: Goal = {name: 'name of the goal', description: 'short description', stepSize: 1, unit: Unit.hrs , weeklyTarget: 1, factor: 1};
  unitsEnum = Unit;

  constructor(private _dataSvc: DataService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
  }

  get diagnostic() { return JSON.stringify(this.model); }
}
