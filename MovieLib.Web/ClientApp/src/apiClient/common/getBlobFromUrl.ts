export const getBlobFromUrl = (myUrl: string) => {
    return new Promise<BlobPart>((resolve, reject) => {
        let request = new XMLHttpRequest();
        request.open('GET', myUrl, true);
        request.responseType = 'blob';
        request.onload = () => {
            resolve(request.response);
        };
        request.onerror = reject;
        request.send();
    })
}