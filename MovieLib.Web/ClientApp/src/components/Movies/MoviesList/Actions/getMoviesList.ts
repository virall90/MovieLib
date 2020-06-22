import {GetMoviesListQuery, MoviesClient} from "../../../../apiClient/apiClient";
import {getErrorsFromApiException} from "../../../../apiClient/getErrorsFromApiException";
import {notification} from "antd";

export const getMoviesList = async (query: GetMoviesListQuery) => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let client = new MoviesClient(apiUrl as string);        
        let result = await client.getMoviesList(query);
        return result ? result : undefined;
    } catch (error) {
        notification.open({
            message: 'Ошибка',
            description:
                getErrorsFromApiException(error)
        });
        return undefined;
    }    
}