export class Progress {
  id: number;
  goalName: string;
  description: string;
  stepSize: number;
  target: number;
  factor: number;
  unit: string;
  progress: number;
  points: number;
  actualPoints: number;
  isSummary: boolean = false;
}
