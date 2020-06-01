import { IUser } from "./user";
import { Injectable } from "@angular/core";

export interface IWork {
  WorkId: number;
  source: string;
  title: string;
  description: string;
  anonMark: number;
  usersMark: number;
  juryMark: number;
  averageMark: number;
  user: IUser;
}
