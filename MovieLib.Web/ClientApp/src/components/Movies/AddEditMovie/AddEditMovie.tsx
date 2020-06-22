import * as React from "react";
import {Button, Form, Input, InputNumber, Spin, Upload} from "antd";
import {useDispatch} from "react-redux";
import {useCallback, useEffect, useState} from "react";
import {addEditMovie} from "./Actions/addEditMovie";
import {UploadOutlined} from "@ant-design/icons/lib";
import {useParams} from "react-router";
import {FileParameter, GetMovieByIdResponse} from "../../../apiClient/apiClient";
import {getMovieById} from "./Actions/getMovieById";
import {RcFile} from "antd/lib/upload";
import {getBlobFromUrl} from "../../../apiClient/common/getBlobFromUrl";

const {TextArea} = Input;

export const AddEditMovie = () => {
    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };
    
    let {movieId} = useParams();
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState([] as string[]);
    const [isPosterFileAdded, setIsPosterFileAdded] = useState(false);
    const [initialMovie, setInitialMovie] = useState(undefined as GetMovieByIdResponse | undefined);
    const [initialMoviePoster, setInitialMoviePoster] = useState(undefined as RcFile | undefined);

    const dispatch = useDispatch()
    const addEditMovieCallback = useCallback(
        async (values: any) => {
            setError([]);
            setIsLoading(true);
            let errors = await addEditMovie(movieId, values.name, values.description, values.releaseYear, values.director,
                values.initialMoviePosterFile || values.posterFile ? {data: values.initialMoviePosterFile ??  values.posterFile} as FileParameter : undefined);
            setIsLoading(false);
            if (errors)
                setError(errors);
            else
                window.location.replace(document.location.href.replace(document.location.pathname, ''));
        },
        [dispatch,]
    )

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };

    const loadMovieData = async (id: string) => {
        setIsLoading(true);
        let movie = await getMovieById(id);
        setInitialMovie(movie);
        if (movie?.havePoster)
            setInitialMoviePoster(
                new File(
                    [await getBlobFromUrl(localStorage.getItem("apiUrl") + "/api/posters/" + movie?.id)],
                    movie.id as string) as RcFile);
        setIsLoading(false);
    }

    useEffect(() => {
        if (movieId)
            loadMovieData(movieId);
    }, [])


    if (isLoading)
        return (
            <div style={{position: "absolute", left: '50%', top: '50%'}}>
                <Spin/>
            </div>);

    return (<>
        <Form
            {...layout}

            name="basic"
            initialValues={{
                name: initialMovie?.name,
                description: initialMovie?.description,
                releaseYear: initialMovie?.releaseYear,
                director: initialMovie?.director,
                initialMoviePosterFile: initialMoviePoster,
            }}
            onFinish={addEditMovieCallback}
            validateMessages={validateMessages}
        >

            <Form.Item
                label="Название"
                name="name"
                rules={[{required: true}]}
            >
                <Input/>
            </Form.Item>
            <Form.Item
                label="Описание"
                name="description"
            >
                <TextArea rows={4}/>
            </Form.Item>
            <Form.Item
                label="Год"
                name="releaseYear"
                rules={[{required: true}]}
            >
                <InputNumber/>
            </Form.Item>
            <Form.Item
                label="Режиссёр"
                name="director"
            >
                <Input/>
            </Form.Item>

            {initialMoviePoster
                ? <Form.Item name="initialMoviePosterFile" label="Постер">
                    <div style={{width: 150, marginBottom: 17}}>
                        <img alt={"Постер"} src={localStorage.getItem("apiUrl") + "/api/posters/" + initialMovie?.id}
                             style={{maxWidth: "100%", maxHeight: "100%"}}/>
                    </div>
                    <Button onClick={() => setInitialMoviePoster(undefined)}>
                        Сменить постер
                    </Button>
                </Form.Item>
                : <Form.Item name="posterFile" label="Постер" valuePropName="posterFileValue"
                             getValueFromEvent={(e: any) => {
                                 let file = e?.fileList[0]?.originFileObj;
                                 setIsPosterFileAdded(file !== undefined);
                                 return file;
                             }}>
                    <Upload name="poster" accept=".jpg,.png" listType="picture" beforeUpload={() => false}
                            multiple={false}>
                        <Button disabled={isPosterFileAdded}>
                            <UploadOutlined/> Добавить постер
                        </Button>
                    </Upload>
                </Form.Item>
            }

            {error.map(item =>
                <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
            )}

            <Form.Item {...tailLayout}>
                <Button type="primary" htmlType="submit" loading={isLoading}>
                    Добавить
                </Button>
            </Form.Item>
        </Form>
    </>);
}