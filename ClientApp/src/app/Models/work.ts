import { IUser } from "./user";
import { Injectable } from "@angular/core";

export interface IWork {
  WorkId: number;
  Source: string;
  ContestId: number;
  Title: string;
  Description: string;
  AnonMark: number;
  UsersMark: number;
  JuryMark: number;
  AverageMark: number;
  User: IUser;
}
