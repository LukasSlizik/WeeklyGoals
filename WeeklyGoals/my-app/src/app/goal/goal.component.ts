import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Goal } from '../models/Goal';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css'],
})
export class GoalComponent implements OnInit {
  submitted = false;

  // dummy model
  model: Goal = new Goal('namex', 'descriptionx', 3, 'hrs', 1, 6);

  units = ['min', 'hrs', 'times', 'pages'];

  constructor(private _dataSvc: DataService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.submitted = true;
  }

  get diagnostic() { return JSON.stringify(this.model); }
}
