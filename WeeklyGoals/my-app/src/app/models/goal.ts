import { Unit } from './units';

export interface Goal {
  name: string;
  description: string;
  stepSize: number;
  unit: Unit;
  weeklyTarget: number;
  factor: number;
}
