import { IUser } from "./user";

export interface IWork {
  source: string;
  title: string;
  description: string;
  anonMark: number;
  usersMark: number;
  juryMark: number;
  averageMark: number;
  user: IUser;
}
