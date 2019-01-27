import { Injectable } from '@angular/core';
import { Observable, ObjectUnsubscribedError } from 'rxjs';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Goal } from './models/Goal';
import { Progress } from './models/Progress';
import { Unit } from './models/units';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private _goalUrl = 'api/Goals';
  private _progressUrl = 'api/Progress';
  private _updateProgressUrl = 'api/UpdateProgress';

  constructor(private _httpClient: HttpClient) { }

  getAllGoals(): Observable<Goal[]> {
    return this._httpClient.get<Goal[]>(this._goalUrl);
    // .catch(this.handleError)
  }

  getAllProgressForWeekDummy(year: number, week: number): Observable<Progress> {
    const p1: Progress = {
      id: 1,
      goalId: 1,
      goalName: 'software skills',
      description: 'write some code',
      stepSize: 1,
      factor: 6,
      points: 2,
      target: 6,
      unit: 'hrs',
    };

    const p2: Progress = {
      id: 2,
      goalId: 2,
      goalName: 'guitar',
      description: 'make some noise',
      stepSize: 20,
      factor: 3,
      points: 60,
      target: 200,
      unit: 'min',
    };

    const p3: Progress = {
      id: 3,
      goalId: 3,
      goalName: 'design patterns',
      description: 'read some design patterns',
      stepSize: 1,
      factor: 1.5,
      points: 1,
      target: 2,
      unit: 'times',
    };

    const p4: Progress = {
      id: 3,
      goalId: 4,
      goalName: 'fitness',
      description: 'do some sports',
      stepSize: 1,
      factor: 3,
      points: 1,
      target: 3,
      unit: 'times',
    };

    const progressData = new Observable<Progress>((observer) => {
      observer.next(p1);
      observer.next(p2);
      observer.next(p3);
      observer.next(p4);

      return observer.complete();
    });

    return progressData;
  }

  getGoalById(id: number): Goal {
    const g: Goal = {
      name: 'guitar',
      description: 'play the guitar',
      factor: 2,
      stepSize: 1,
      unit: Unit.times,
      weeklyTarget: 4,
    };

    return g;
  }

  getAllProgressForWeek(year: number, week: number): Observable<Progress[]> {
    const httpParams = new HttpParams().set('year', year.toString()).set('week', week.toString())
    return this._httpClient.get<Progress[]>(this._progressUrl, { params: httpParams });
    // .catch(this.handleError);
  }

  updateProgress(progressId: number, points: number): void {
    this._httpClient.get(this._updateProgressUrl, {
      params: new HttpParams()
        .append('progressId', progressId.toString())
        .append('points', points.toString())
    }); // .catch(this.handleError).subscribe();
  }

  createNewGoal(goal: Goal): void {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    // @Html.AntiForgeryToken()

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
