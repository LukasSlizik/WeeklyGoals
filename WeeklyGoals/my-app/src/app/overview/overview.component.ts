import { Component, OnInit, HostListener } from '@angular/core';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  // progress: Progress[];
  // summaryProgress: Progress = this.getSummaryProgress();
  selectedDateAsWeek: string;

  constructor() {
    const today = new Date();
    this.selectedDateAsWeek = this.getWeekAsHtml(today);
  }

  ngOnInit(): void { }

  private weekChanged(event: any): void {
    const selectedDate = event.target.valueAsDate;
    this.selectedDateAsWeek = this.getWeekAsHtml(selectedDate);
  }

  private getWeekAsHtml(date: Date): string {
    const year = date.getFullYear();
    const week = this.getWeekOfTheYear(date);

    return `${year}-W${week}`;
  }

  private getWeekOfTheYear(d: Date): number {
    // Copy date so don't modify original
    d = new Date(+d);
    d.setHours(0, 0, 0);

    // Set to nearest Thursday: current date + 4 - current day number
    // Make Sunday's day number 7
    d.setDate(d.getDate() + 4 - (d.getDay() || 7));

    // Get first day of year
    const yearStart = new Date(d.getFullYear(), 0, 1);

    // Calculate full weeks to nearest Thursday
    const weekNo = Math.ceil((((d.valueOf() - yearStart.valueOf()) / 86400000) + 1) / 7);

    // Return array of year and week number
    return weekNo;
  }

  //   this.selectedWeek = ProgressHelper.convertDateToHtmlInputFormat(currentDate);
  //   const currentYear = currentDate.getFullYear();
  //   const currentWeek = ProgressHelper.getWeekOfTheYear(currentDate);

  //   this.setProgress(currentYear, currentWeek);
  // }

  // private setProgress(year: number, week: number) {
  //   this._progressSvc.getAllProgressForWeek(year, week).subscribe(progress => {
  //     this.progress = progress;
  //     this.progress.push(this.summaryProgress);
  //     this.calculateSummary();
  //   });
  // }

  // public calculateSummary(): void {
  //   let summary = 0;

  //   for (const p of this.progress.filter(prog => prog.isSummary != true)) {
  //     summary += (p.points / p.target) * p.factor;
  //   }

  //   this.summaryProgress.actualPoints = summary;
  // }

  // public onUpdateProgress(progress: Progress) {
  //   this.calculateSummary();
  // }

  // private getSummaryProgress(): Progress {
  //   const p = new Progress();
  //   p.actualPoints = -1;
  //   p.isSummary = true;

  //   return p;
  // }



}
