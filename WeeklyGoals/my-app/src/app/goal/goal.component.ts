import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Goal } from '../models/Goal';
import { Unit } from '../models/units';
import { ActivatedRoute } from '@angular/router';
import { Mode } from '../models/Mode';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css'],
})
export class GoalComponent implements OnInit {
  submitted = false;
  model: Goal;
  unitsEnum = Unit;
  mode: Mode; // default

  constructor(private _dataSvc: DataService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.mode = this.route.snapshot.data['mode'];

    if (this.mode === Mode.edit) {
      this.model = this._dataSvc.getGoalById(+(this.route.snapshot.paramMap.get('id')));
    }
  }

  onSubmit() {
    this.submitted = true;
  }

  get diagnostic() { return JSON.stringify(this.model); }
}
