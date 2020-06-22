import {FileParameter, MoviesClient} from "../../../../apiClient/apiClient";
import {getErrorsFromApiException} from "../../../../apiClient/getErrorsFromApiException";

export const addEditMovie = async (
    id: string | null | undefined,
    name: string | null | undefined,
    description: string | null | undefined,
    releaseYear: number | null | undefined,
    director: string | null | undefined,
    posterFile: FileParameter | null | undefined) => {
    try {
        let apiUrl = localStorage.getItem("apiUrl");
        let client = new MoviesClient(apiUrl as string);
        await client.addEditMovie(localStorage.getItem("apiToken"),id,name,description,releaseYear,director,posterFile);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};