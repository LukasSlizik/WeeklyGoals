import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { IProgress } from "../models/IProgress";
import { Observable } from 'rxjs/Observable';
import { HttpParams } from "@angular/common/http";

@Injectable()
export class ProgressService {
    private _progressUrl: string = 'Home/GetProgressForWeek'
    private _updateProgressUrl: string = 'Home/UpdateProgress';

    constructor(private _httpClient: HttpClient) { }

    getAllProgressForWeek(weekId: number): Observable<IProgress[]> {
        return this._httpClient.get<IProgress[]>(this._progressUrl, { params: new HttpParams().set('weekId', weekId.toString()) })
            .catch(this.handleError)
    }

    updateProgress(progressId: number, points: number): void {
        this._httpClient.get(this._updateProgressUrl, {
            params: new HttpParams()
                .append('progressId', progressId.toString())
                .append('points', points.toString())
        }).catch(this.handleError).subscribe();
    }

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
}