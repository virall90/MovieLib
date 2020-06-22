export const initApi = async () => {
    try {
        let apiUrl: string | undefined = undefined;

        let resp = (await fetch("ApiConfiguration/GetApiUrl"));
        if (resp.ok)
            apiUrl = await resp.text();

        //TODO: Оставил только для запуска через npm start
        if(!apiUrl?.startsWith("http"))
            apiUrl = "https://localhost:5001";

        localStorage.setItem("apiUrl",apiUrl);
        return undefined;
    } catch (error) {
        return "Ошибка подключения";
    }
};