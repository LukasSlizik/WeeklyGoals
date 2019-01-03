import { Directive, ElementRef, Renderer2, OnInit, Input } from '@angular/core';
import { Progress } from './models/progress';

@Directive({
  selector: '[appProgline]'
})
export class ProglineDirective implements OnInit {
  // tslint:disable-next-line:no-input-rename
  @Input('allprogress') allProgress: Progress[] = [];

  // tslint:disable-next-line:no-input-rename
  @Input('index') index: number;

  private appendValue(value: any) {
    const td = document.createElement('td');
    const span = document.createElement('span');

    td.appendChild(span);
    span.innerText = value;

    this.renderer.appendChild(this.el.nativeElement, td);
  }

  private appendProgress(value: number, max: number) {
    const td = document.createElement('td');
    const span = document.createElement('span');
    const prog = document.createElement('progress');

    const minusBtn = document.createElement('button');
    minusBtn.innerText = '-';
    minusBtn.addEventListener('click', (e: Event) => console.log('minus Btn clicked'));

    const plusBtn = document.createElement('button');
    plusBtn.innerText = '+';
    plusBtn.addEventListener('click', (e: Event) => console.log('plus Btn clicked'));

    span.appendChild(minusBtn);
    span.appendChild(prog);
    span.appendChild(plusBtn);

    td.appendChild(span);
    prog.value = value;
    prog.max = max;

    this.renderer.appendChild(this.el.nativeElement, td);
  }

  ngOnInit(): void {
    if (this.index !== -1) {
      this.appendProgressLine();
    } else {
      this.appendSummaryLine();
    }
  }

  appendSummaryLine(): any {
    this.appendValue('');
    this.appendValue('');
    this.appendValue('');
    this.appendValue('');
    this.appendValue('');
    this.appendValue('');
    this.appendValue('');

    const allActualPoints = this.allProgress.map(p => ((p.points / p.target) * p.factor));
    const allFactors = this.allProgress.map(p => p.factor);

    const totalPoints = allActualPoints.reduce((previous, current) => previous + current);
    const totalFactors = allFactors.reduce((previous, current) => previous + current);

    this.appendProgress(totalPoints, totalFactors);
    this.appendValue(totalPoints);
  }

  constructor(private el: ElementRef, private renderer: Renderer2) {
  }

  private appendProgressLine() {
    const actualProgress = this.allProgress[this.index];
    this.appendValue(actualProgress.goalName);
    this.appendValue(actualProgress.description);
    this.appendValue(actualProgress.stepSize);
    this.appendValue(actualProgress.unit);
    this.appendValue(actualProgress.target);
    this.appendValue(actualProgress.factor);
    this.appendValue(actualProgress.points);
    this.appendProgress(actualProgress.points, actualProgress.target);
    this.appendValue(((actualProgress.points / actualProgress.target) * actualProgress.factor).toFixed(2));
  }
}
