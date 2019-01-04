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

    td.appendChild(span);
    span.innerText = value;

    this.renderer.appendChild(this.el.nativeElement, td);
  }

  createProgressButton(innerText: string, listener: EventListener): HTMLButtonElement {
    const progressBtn = document.createElement('button');
    progressBtn.innerText = innerText;
    progressBtn.addEventListener('click', listener);

    return progressBtn;
  }

  createProgressElement(value: number, max: number): HTMLProgressElement {
    const prog = document.createElement('progress');
    prog.value = value;
    prog.max = max;

    return prog;
  }

  private appendProgress(value: number, max: number, withButtons: boolean) {
    const td = document.createElement('td');
    const span = document.createElement('span');

    if (withButtons) {
      span.appendChild(this.createProgressButton('-', (e: Event) => this.decreaseEvent.emit(this.index)));
    }

    span.appendChild(this.createProgressElement(value, max));

    if (withButtons) {
      span.appendChild(this.createProgressButton('+', (e: Event) => this.increaseEvent.emit(this.index)));
    }

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

    const allActualPoints = this.allProgress.map(p => ((p.points / p.target) * p.factor));
    const allFactors = this.allProgress.map(p => p.factor);

    const totalPoints = allActualPoints.reduce((previous, current) => previous + current);
    const totalFactors = allFactors.reduce((previous, current) => previous + current);

    this.appendProgress(totalPoints, totalFactors, false);
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
    this.appendProgress(actualProgress.points, actualProgress.target, true);
    this.appendValue(((actualProgress.points / actualProgress.target) * actualProgress.factor).toFixed(2));
  }
}
