import { Component, OnInit } from '@angular/core';
import { GoalService } from "../services/goal.service";
import { Goal } from "../models/Goal";

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent {
  private _goals: Goal[];
  private _selectedGoal: Goal;

  constructor(private _goalSvc: GoalService) { }

  ngOnInit(): void {
    this._goalSvc.getAllGoals().subscribe(goals => {
      this._goals = goals;
    });
  }

  edit($event: any): void {
    console.log($event);
    var goalId = Number($event.target.id);

    this._selectedGoal = this._goals.filter(goal => goal.id === goalId)[0];
  }
}
