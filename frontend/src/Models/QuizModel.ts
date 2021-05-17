import { CourseModel } from "./CourseModel";
import { QuestionModel } from "./QuestionModel";
import { QuestionResponseModel } from "./QuestionResponseModel";

export interface QuizModel{
    id: number;
    name: string;
    course: CourseModel;
    questions: QuestionModel[];
    startTime: Date;
    endTime: Date;
    numberOfMinutes: number;
    visibleForStudents: boolean;
    submissions: QuestionResponseModel[];
}