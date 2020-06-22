import {AppActionWithDispatch} from "../index";
import {
    UserClient,
    UserGetInfoQuery,
    UserLoginCommand,
    UserLogoutCommand,
    UserRegisterCommand
} from "../../apiClient/apiClient";
import {setUserInfo} from "./actions";
import {getErrorsFromApiException} from "../../apiClient/getErrorsFromApiException";

export const getUserInfo = (): AppActionWithDispatch => async dispatch => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let token = localStorage.getItem("apiToken");
        if (token) {
            let client = new UserClient(apiUrl as string);
            const query: UserGetInfoQuery = {token: token};
            let result = await client.getInfo(query);
            dispatch(setUserInfo(result));
        } else
            dispatch(setUserInfo(undefined));
    } catch (error) {
        // localStorage.removeItem("apiToken");
        //notify error.response?
        dispatch(setUserInfo(undefined));
    }
};

export const logout = (): AppActionWithDispatch => async dispatch => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let token = localStorage.getItem("apiToken");
        if (token) {
            let client = new UserClient(apiUrl as string);
            let command: UserLogoutCommand = {token: token};
            await client.logout(command);
        }
    } catch (error) {
        //notify error.response?
    }
    localStorage.removeItem("apiToken");
    dispatch(setUserInfo(undefined));
};

export const register = (command: UserRegisterCommand):
    AppActionWithDispatch<Promise<string[] | undefined>> => async dispatch => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let client = new UserClient(apiUrl as string);
        let result = await client.register(command);

        if (result.token) {
            localStorage.setItem('apiToken', result.token);
        }
        await getUserInfo()(dispatch);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};

export const login = (command: UserLoginCommand): AppActionWithDispatch<Promise<string[] | undefined>> => async dispatch => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let client = new UserClient(apiUrl as string);
        let result = await client.login(command);

        if (result?.token) {
            localStorage.setItem('apiToken', result.token);
        }
        await getUserInfo()(dispatch);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};