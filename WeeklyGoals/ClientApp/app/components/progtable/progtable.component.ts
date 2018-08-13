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
        var currentDate = new Date();

        this.selectedWeek = ProgressHelper.convertDateToHtmlInputFormat(currentDate);
        var currentYear = currentDate.getFullYear();
        var currentWeek = ProgressHelper.getWeekOfTheYear(currentDate);

        this._progressSvc.getAllProgressForWeek(currentYear, currentWeek).subscribe(progress => {
            this.progress = progress;
        });
    }



    private weekSelected(): void {
        var parsedDate = ProgressHelper.parseHtmlWeek(this.selectedWeek);

        this._progressSvc.getAllProgressForWeek(parsedDate.year, parsedDate.week).subscribe(progress => {
            this.progress = progress;
        });
    }


}