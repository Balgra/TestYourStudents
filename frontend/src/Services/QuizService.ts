import { QuestionResponseModel } from "../Models/QuestionResponseModel";
import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = (process.env.NODE_ENV === "production" ? "https://api.testyourstudents.adelinchis.ro" : "https://localhost:5001") + '/api/';

export const GetQuizzes = async (courseId: number): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/quiz`, {headers: {'Content-Type': 'application/json', ...GetAuthHeader()}});
    const body = response.json();
    const data = await body;
    return data;
}

export const SubmitQuiz = async (courseId: number, quizId: number, responses: QuestionResponseModel[]) : Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/quiz/submit`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}, body: JSON.stringify({quizId: quizId, responses: responses})});
    if(response.ok)
        return;
    return new Promise((res, rej) => rej("Something went wrong!"));
}

export const CreateQuiz = async (courseId: number, quiz: any) : Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/quiz`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}, body: JSON.stringify(quiz)});
    if(response.ok)
        return;
    return new Promise((res, rej) => rej("Something went wrong!"));
}