import axios from "axios";
import { ResponseModel } from "./ResponseModel";
axios.defaults.baseURL = "https://localhost:7237/User";

export const signupReq =async (url: string, data: any) => {
    try {
        const response: ResponseModel = await axios.post(url, data, {});
        debugger
        return response?.data;
    }
    catch (e) {
        console.error("error", e);
    }
};
