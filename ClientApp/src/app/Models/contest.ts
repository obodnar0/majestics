import { IWork } from "./work"

export interface IContest {
  ContestId: number;
  title: string; 
  description: string;
  works: IWork[];
}
