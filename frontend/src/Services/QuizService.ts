import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = (process.env.NODE_ENV === "production" ? "https://api.testyourstudents.adelinchis.ro" : "https://localhost:5001") + '/api/';

export const GetQuizzes = async (courseId: number): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/quiz`, {headers: {'Content-Type': 'application/json', ...GetAuthHeader()}});
    const body = response.json();
    const data = await body;
    return data;
}
