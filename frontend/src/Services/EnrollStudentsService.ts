import { GetAuthHeader } from "./AuthService";

const baseCourseApiUrl = (process.env.NODE_ENV === "production" ? "https://api.testyourstudents.adelinchis.ro" : "https://localhost:5001") + "/api/";

export const EnrollStudents = async (studentEmails: string[], courseId: number): Promise<any> => {
    const response = await fetch(`${baseCourseApiUrl}${courseId}/enroll`, {method: 'POST', headers: {'Content-Type': 'application/json', ...GetAuthHeader()}, body: JSON.stringify({studentEmails: studentEmails})});
    if(response.ok)
        return;
    return new Promise((res, rej) => rej("Something went wrong!"));
}

