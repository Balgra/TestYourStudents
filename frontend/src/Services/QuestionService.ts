import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = "https://localhost:5001" + '/api/';

export const CreateQuestion = async (questionName: string, courseId: number, quizId: number): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/question`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}, body: JSON.stringify({name: questionName, quizId: quizId})});
    if(response.ok)
        return;
    return new Promise((res, rej) => rej("Something went wrong!"));
}
