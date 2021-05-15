import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = (process.env.NODE_ENV === "production" ? "https://api.testyourstudents.adelinchis.ro" : "https://localhost:5001") + '/api/courses';

export const GetCourses = async (): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}`, {headers: {'Content-Type': 'application/json', ...GetAuthHeader()}});
    const body = response.json();
    const data = await body;
    return data;
}
