import { Directive, ElementRef, Renderer2, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Progress } from './models/progress';

@Directive({
  selector: '[appProgline]'
})
export class ProglineDirective implements OnInit {
  // tslint:disable-next-line:no-input-rename
  @Input('allprogress') allProgress: Progress[] = [];

  // tslint:disable-next-line:no-input-rename
  @Input('index') index: number;

  @Output() increaseEvent: EventEmitter<number> = new EventEmitter();
  @Output() decreaseEvent: EventEmitter<number> = new EventEmitter();

  private appendValue(value: any) {
    const td = document.createElement('td');
    const span = document.createElement('span');
    span.innerText = value;

    td.appendChild(span);
    this.renderer.appendChild(this.el.nativeElement, td);
  }

  private appendProgress(value: number, max: number) {
    const td = document.createElement('td');
    const span = document.createElement('span');
    const prog = document.createElement('progress');
    prog.value = value;
    prog.max = max;

    span.appendChild(prog);

    td.appendChild(span);
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
    this.appendValue('');

    const allActualPoints = this.allProgress.map(p => ((p.points / p.target) * p.factor));
    const allFactors = this.allProgress.map(p => p.factor);

    const totalPoints = allActualPoints.reduce((previous, current) => previous + current);
    const totalFactors = allFactors.reduce((previous, current) => previous + current);

    this.appendProgress(totalPoints, totalFactors);
    this.appendValue('');
    this.appendValue(totalPoints);
  }

  constructor(private el: ElementRef, private renderer: Renderer2) {
  }

  private appendProgressLine() {
    const currentProgress = this.allProgress[this.index];

    this.appendValue(currentProgress.goalName);
    this.appendValue(currentProgress.description);
    this.appendValue(currentProgress.stepSize);
    this.appendValue(currentProgress.unit);
    this.appendValue(currentProgress.target);
    this.appendValue(currentProgress.factor);
    this.appendValue(currentProgress.points);
    this.appendButton('-', () => this.decreaseEvent.emit(this.index));
    this.appendProgress(currentProgress.points, currentProgress.target);
    this.appendButton('+', () => this.increaseEvent.emit(this.index));
    this.appendValue(((currentProgress.points / currentProgress.target) * currentProgress.factor).toFixed(2));
  }

  appendButton(innerText: string, listener: EventListener): void {
    const td = document.createElement('td');
    const span = document.createElement('span');
    const btn = document.createElement('button');
    btn.innerText = innerText;
    btn.addEventListener('click', listener);

    span.appendChild(btn);
    td.appendChild(span);

    this.renderer.appendChild(this.el.nativeElement, td);
  }
}
