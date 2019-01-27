export interface Progress {
  id: number;
  goalId: number;
  goalName: string;
  description: string;
  stepSize: number;
  target: number;
  factor: number;
  unit: string;
  points: number;
}
