import { Component, OnInit, HostListener } from '@angular/core';
import { Progress } from '../models/progress';
import { DataService } from '../data.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {
  _progress: Progress[] = [];
  selectedDateAsWeek: string;

  constructor(private _dataService: DataService) {
    const today = new Date();
    this.selectedDateAsWeek = this.getWeekAsHtml(today);
  }

  ngOnInit(): void {
    this._dataService.getAllProgressForWeek(1998, 12).subscribe((data) => {
      // this._progress.push(data);
      this._progress = data;
    });
  }

  private weekChanged(event: any): void {
    const selectedDate = event.target.valueAsDate;
    this.selectedDateAsWeek = this.getWeekAsHtml(selectedDate);
  }

  private getWeekAsHtml(date: Date): string {
    const year = date.getFullYear();
    let week = this.getWeekOfTheYear(date).toString();

    if (week.length < 2) {
      week = '0' + week;
    }

    return `${year}-W${week}`;
  }

  decrease(selProgress: Progress): void {
    console.log('decrease');
  }

  increase(selProgress: Progress): void {
    console.log('increase');
  }

  deleteProgress(selProgress: Progress): void {
    console.log('delete');
  }

  getTotalPoints(): number {
    // const allActualPoints = this._progress.map(p => ((p.points / p.target) * p.factor));
    // const totalPoints = allActualPoints.reduce((previous, current) => previous + current);

    // return totalPoints;

    return 5;
  }

  getTotalFactors(): number {
    // const allFactors = this._progress.map(p => p.factor);
    // const totalFactors = allFactors.reduce((previous, current) => previous + current);

    // return totalFactors;

    return 6;
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
}
