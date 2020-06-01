import { IWork } from "./work"

export interface IContest {
  ContestId: number;
  Title: string; 
  Description: string;
  Works: IWork[];
}
