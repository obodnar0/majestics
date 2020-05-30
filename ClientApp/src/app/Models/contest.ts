import { Work } from "./work"

export interface IContest {
  contestId: number;
  title: string; 
  description: string;
  works: Work[];
}
