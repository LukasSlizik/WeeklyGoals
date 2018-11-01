import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { ProgressService } from "../services/progress.service";
import { Progress } from "../models/Progress";
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";

@Component({
  selector: '[progline]',
  providers: [ProgressService],
  templateUrl: './progline.component.html'
})

export class ProglineComponent {
  @Input('progline') progress: Progress;
  @Output() updateProgress = new EventEmitter<Progress>();

  constructor(private _progressSvc: ProgressService) {
  }

  ngOnInit(): void {
    // do not update the summary line
    if (!this.progress.isSummary)
      this.progress.actualPoints = this.getActualPoints();
  }

  private getActualPoints(): number {
    return (this.progress.points / this.progress.target) * this.progress.factor;
  }

  public step($event: any): void {
    var target = $event.currentTarget;
    var id = target.attributes.id.nodeValue;
    switch (id) {
      case "up":
        this.progress.points += this.progress.stepSize;
        break;
      case "down":
        this.progress.points -= this.progress.stepSize;
        break;
      default:
        console.log("invalid value: " + id);
    }

    this.progress.actualPoints = this.getActualPoints();
    this._progressSvc.updateProgress(this.progress.id, this.progress.points);
    this.updateProgress.emit(this.progress);
  }
}
