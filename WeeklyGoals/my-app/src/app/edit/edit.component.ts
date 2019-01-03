import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Goal } from '../models/Goal';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  private _goals: Goal[];
  private _selectedGoal: Goal;

  constructor(private _dataSvc: DataService) { }

  ngOnInit(): void {
    this._dataSvc.getAllGoals().subscribe(goals => {
      this._goals = goals;
    });
  }

  edit($event: any): void {
    console.log($event);
    const goalId = Number($event.target.id);

    this._selectedGoal = this._goals.filter(goal => goal.id === goalId)[0];
  }
}
