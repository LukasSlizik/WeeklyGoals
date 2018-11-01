import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Progress } from "../models/Progress";
import { Goal } from "../models/Goal";
import { Observable } from 'rxjs';
//import 'rxjs/add/operator/catch';

@Injectable()
export class ProgressService {
  private _progressUrl: string = 'Home/GetProgressForWeek'
  private _updateProgressUrl: string = 'Home/UpdateProgress';

  constructor(private _httpClient: HttpClient) { }

  getAllProgressForWeek(year: number, week: number): Observable<Progress[]> {
    return this._httpClient.get<Progress[]>(this._progressUrl, { params: new HttpParams().set('year', year.toString()).set('week', week.toString()) });
      //.catch(this.handleError);
  }

  updateProgress(progressId: number, points: number): void {
    this._httpClient.get(this._updateProgressUrl, {
      params: new HttpParams()
        .append('progressId', progressId.toString())
        .append('points', points.toString())
    }); //.catch(this.handleError).subscribe();
  }

  createNewGoal(goal: Goal): void {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    //@Html.AntiForgeryToken()

    this._httpClient.post('home/create', JSON.stringify(goal), { headers: headers }).subscribe();
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
