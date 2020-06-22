import {ApiException} from "./apiClient";

export interface IErrors {
    errors: string[],
}

export const getErrorsFromApiException = (error: any) => {
    if (error.isApiException) {
        let apiException = error as ApiException;
        if (apiException.response) {
            try {
                let responseParsed = JSON.parse(apiException.response);
                if (responseParsed.errors)
                    return (responseParsed as IErrors).errors;
            } catch {
                return ["Ошибка сервера"];
            }
        }
        if (apiException.status === 401)
            return ["Неавторизованный доступ"];

    }
    return ["Ошибка сервера"];
}


