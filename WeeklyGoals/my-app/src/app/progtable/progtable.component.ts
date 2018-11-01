import { Component, OnInit } from '@angular/core';
import { ProgressService } from "../services/progress.service";
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Http } from "@angular/http";
import { Progress } from "../models/Progress";
import { Observable } from 'rxjs';
import { ProgressHelper } from "../helpers/progress-helper";

@Component({
  selector: 'progtable',
  templateUrl: './progtable.component.html',
})
export class ProgtableComponent {

  progress: Progress[];
  summaryProgress: Progress = this.getSummaryProgress();
  selectedWeek: string;

  constructor(private _progressSvc: ProgressService) { }

  ngOnInit(): void {
    var currentDate = new Date();

    this.selectedWeek = ProgressHelper.convertDateToHtmlInputFormat(currentDate);
    var currentYear = currentDate.getFullYear();
    var currentWeek = ProgressHelper.getWeekOfTheYear(currentDate);

    this.setProgress(currentYear, currentWeek);
  }

  private setProgress(year: number, week: number) {
    this._progressSvc.getAllProgressForWeek(year, week).subscribe(progress => {
      this.progress = progress;
      this.progress.push(this.summaryProgress);
      this.calculateSummary();
    });
  }

  public calculateSummary(): void {
    var summary = 0;

    for (let p of this.progress.filter(prog => prog.isSummary != true)) {
      summary += (p.points / p.target) * p.factor;
    }

    this.summaryProgress.actualPoints = summary;
  }

  public onUpdateProgress(progress: Progress) {
    this.calculateSummary();
  }

  private getSummaryProgress(): Progress {
    var p = new Progress();
    p.actualPoints = -1;
    p.isSummary = true;

    return p;
  }

  private weekSelected(): void {
    var parsedDate = ProgressHelper.parseHtmlWeek(this.selectedWeek);
    this.setProgress(parsedDate.year, parsedDate.week);
  }

}
