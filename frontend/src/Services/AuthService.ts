import { resolve } from "dns";
import { LoginModel } from "../Models/LoginModel";
import { RegisterProfessorModel } from "../Models/RegisterProfessorModel";

const GetAccessToken = () => {
    const storage = localStorage.getItem("session");
    if(storage) {
        const session = JSON.parse(storage);
        return session?.accessToken;
    }
    return undefined;
 };
const parseJwt = (token: string) =>  {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};
 
 const SetToken = (token: string) => {
     if(!token)
         return;
    localStorage.setItem('session', JSON.stringify({...parseJwt(token), accessToken: token}));
 }
 
 export const GetAuthHeader = () => {
     return {
         Authorization: "Bearer " + GetAccessToken()
     };
 };
 
 export const IsAuthenticated = () => {
    const storage = localStorage.getItem("session");
    debugger;
    if(storage) {
        const session = JSON.parse(storage);
        if(!(session && session.accessToken))
            return false;
        if (Date.now() >= session?.exp * 1000) {
            return false;
        }
        return true;
    }
    return false;
 }
 
 const baseIdentityUrl = "https://localhost:5001" + '/api/Identity';
 
 export const Login = async (request: LoginModel): Promise<string> => {
     const response = await fetch(`${baseIdentityUrl}/login`, {method: 'POST', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(request)});
     const body = response.json();
     const data = await body;
     if(response.ok) {
         
         SetToken(data.token);
     }
     else return new Promise<string>((r, reject) => reject(data.errors));
     return "Login successful!";
 
 }

 export const RegisterAsProfessor = async (request: RegisterProfessorModel): Promise<string> => {
    const response = await fetch(`${baseIdentityUrl}/RegisterAsProfessor`, {method: 'POST', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(request)});
    const body = response.json();
    const data = await body;
    if(response.ok) {
        SetToken(data.token);
    }
    else return new Promise<string>((r, reject) => reject(data.errors));
    return "Register successful!";

}

export const RegisterAsStudent = async (request: RegisterProfessorModel): Promise<string> => {
    const response = await fetch(`${baseIdentityUrl}/RegisterAsStudent`, {method: 'POST', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(request)});
    const body = response.json();
    const data = await body;
    if(response.ok) {
        SetToken(data.token);
    }
    else return new Promise<string>((r, reject) => reject(data.errors));
    return "Register successful!";

}

 
 export const Logout = () => {
     localStorage.removeItem('session');
 }
 
 