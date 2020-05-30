import { User } from "./user";

export class Work {
  source: string;
  title: string;
  description: string;
  anonMark: number;
  usersMark: number;
  juryMark: number;
  averageMark: number;
  user: User;
}
