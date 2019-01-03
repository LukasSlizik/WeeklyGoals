export interface Goal {
  id: number;
  name: string;
  description: string;
  stepSize: number;
  unit: string;
  weeklyTarget: number;
  factor: number;
  startingYear: number;
  startingWeek: number;
}
