import { Component } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
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
    private _progressUrl: string = 'Home/GetProgressForWeek?weekId=2'
    progress: IProgress[];

    constructor(private _httpClient: HttpClient) { }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }

    ngOnInit(): void {
        this._httpClient.get<IProgress[]>(this._progressUrl)
            .catch(this.handleError)
            .subscribe(progress => {
                this.progress = progress;
            });
    }
}