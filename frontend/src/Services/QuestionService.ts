import { QuestionModel } from "../Models/QuestionModel";
import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = (process.env.NODE_ENV === "production" ? "https://api.testyourstudents.adelinchis.ro" : "https://localhost:5001") + '/api/';

export const CreateQuestion = async (questionName: string, courseId: number, quizId: number): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/question`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}, body: JSON.stringify({name: questionName, quizId: quizId})});
    if(response.ok)
        return;
    return new Promise((res, rej) => rej("Something went wrong!"));
}

export const StartQuiz = async (quizId: number, courseId: number): Promise<QuestionModel[]> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/question/session?quizId=${quizId}`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}});
    const body = response.json();
    const data = await body;
    return data;
}
