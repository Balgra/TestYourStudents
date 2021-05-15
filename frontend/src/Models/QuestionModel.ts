import { CourseModel } from "./CourseModel";

export interface QuestionModel{
    id: number;
    questionName: string;
    course: CourseModel;
}