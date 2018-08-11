import { Component } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Http } from "@angular/http";
import { IProgress } from "../../models/IProgress";
import { Observable } from 'rxjs/Observable';
import { ProgressHelper } from "../../helpers/progressHelper";

@Component({
    selector: 'progtable',
    templateUrl: './progtable.component.html'
})

export class ProgtableComponent {

    progress: IProgress[];
    selectedWeek: string;

    constructor(private _progressSvc: ProgressService) { }

    ngOnInit(): void {
        this.setCurrentDate();
    }

    // 
    private setCurrentDate(): void {
        var currentDate = new Date();
        var currentYear = currentDate.getFullYear();
        var currentWeek = ProgressHelper.getWeekOfTheYear(currentDate);

        // formatting needed for html tag - <input type='week' />
        this.selectedWeek = `${currentYear}-W${this.pad(currentWeek, 2)}`;

        this._progressSvc.getAllProgressForWeek(currentYear, currentWeek).subscribe(progress => {
            this.progress = progress;
        });
    }

    // Returns a new string of a specified length in which the beginning of the number is padded with zeros.
    private pad(number: number, length: number): string{
        var s = number.toString();
        while (s.length < length)
            s = "0" + s;
        return s;
    }

    private weekSelected(): void {
        var parsedDate = ProgressHelper.parseHtmlWeek(this.selectedWeek);

        this._progressSvc.getAllProgressForWeek(parsedDate.year, parsedDate.week).subscribe(progress => {
            this.progress = progress;
        });
    }


}