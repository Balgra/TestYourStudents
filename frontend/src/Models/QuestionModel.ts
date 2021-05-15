import { CourseModel } from "./CourseModel";
import { QuizModel } from "./QuizModel";

export interface QuestionModel{
    id: number;
    questionName: string;
    quiz: QuizModel;
}