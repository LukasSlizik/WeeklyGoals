import { Component, OnInit } from '@angular/core';
import { ProgressService } from '../services/progress.service';
import { Progress } from '../models/Progress';
import { ProgressHelper } from '../helpers/progress-helper';

@Component({
  selector: 'app-progtable',
  templateUrl: './progtable.component.html',
})
export class ProgtableComponent implements OnInit {

  progress: Progress[];
  summaryProgress: Progress = this.getSummaryProgress();
  selectedWeek: string;

  constructor(private _progressSvc: ProgressService) { }

  ngOnInit(): void {
    const currentDate = new Date();

    this.selectedWeek = ProgressHelper.convertDateToHtmlInputFormat(currentDate);
    const currentYear = currentDate.getFullYear();
    const currentWeek = ProgressHelper.getWeekOfTheYear(currentDate);

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
    let summary = 0;

    for (const p of this.progress.filter(prog => prog.isSummary != true)) {
      summary += (p.points / p.target) * p.factor;
    }

    this.summaryProgress.actualPoints = summary;
  }

  public onUpdateProgress(progress: Progress) {
    this.calculateSummary();
  }

  private getSummaryProgress(): Progress {
    const p = new Progress();
    p.actualPoints = -1;
    p.isSummary = true;

    return p;
  }

  private weekSelected(): void {
    const parsedDate = ProgressHelper.parseHtmlWeek(this.selectedWeek);
    this.setProgress(parsedDate.year, parsedDate.week);
  }

}
