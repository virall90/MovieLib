import {GetMovieByIdQuery, MoviesClient} from "../../../../apiClient/apiClient";
import {getErrorsFromApiException} from "../../../../apiClient/getErrorsFromApiException";
import {notification} from "antd";

export const getMovieById = async (id: string) => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let client = new MoviesClient(apiUrl as string);
        let query: GetMovieByIdQuery = {movieId:id};
        return await client.getMovieById(query);
    } catch (error) {
        notification.open({
            message: 'Ошибка',
            description:
                getErrorsFromApiException(error)
        });
        return undefined;
    }
};