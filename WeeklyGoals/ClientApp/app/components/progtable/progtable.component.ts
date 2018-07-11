import { Component } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Http } from "@angular/http";
import { IProgress } from "../../models/IProgress";
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

@Component({
    selector: 'progtable',
    templateUrl: './progtable.component.html'
})

export class ProgtableComponent {

    progress: IProgress[];
    calendarValue: string = "2018-W02";
    initialWeekId: number = 2;
    weekIdRegex: string = "W(.*)";

    constructor(private _httpClient: HttpClient, private _progressSvc: ProgressService) { }

    ngOnInit(): void {
        this._progressSvc.getAllProgressForWeek(this.initialWeekId).subscribe(progress => {
            this.progress = progress;
        });
    }

    weekSelected(): void {
        var weekId = this.parseSelectedWeek();

        this._progressSvc.getAllProgressForWeek(weekId).subscribe(progress => {
            this.progress = progress;
        });
    }

    parseSelectedWeek(): number
    {
        var regex = new RegExp(this.weekIdRegex);
        var match = regex.exec(this.calendarValue);
        var weekId: number = 1;   // fallback
        if (match != null)
            weekId = Number(match[1]);

        return weekId;
    }
}