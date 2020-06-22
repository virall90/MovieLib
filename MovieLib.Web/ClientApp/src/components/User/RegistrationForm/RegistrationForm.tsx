import * as React from "react";
import {Form, Input, Button} from 'antd';
import {useCallback, useState} from "react";
import {register} from "../../../store/User/thunks";
import {useDispatch} from "react-redux";
import {UserRegisterCommand} from "../../../apiClient/apiClient";


export const RegistrationForm = () => {
    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };

    const [isLoading, setIsLoading] = useState(false);
    const [errors, setErrors] = useState([] as string[]);
    const [result, setResult] = useState(undefined as string | undefined);

    const dispatch = useDispatch();

    const registerCallback = useCallback(
        async (values: any) => {
            setErrors([]);
            setResult(undefined);
            setIsLoading(true);
            let command: UserRegisterCommand = {
                email: values.email,
                password: values.password,
                userName: values.userName
            };
            let errors = await register(command)(dispatch);
            if (errors) setErrors(errors);
            else setResult("Удачная регистрация.");
            setIsLoading(false);
        },
        [dispatch]);

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };

    return (
        <>
            <p style={{textAlign: "center", fontSize: "1.5rem"}}>Регистрация нового пользователя</p>
            <Form
                {...layout}
                name="basic"
                initialValues={{remember: true}}
                onFinish={registerCallback}
                validateMessages={validateMessages}
            >
                <Form.Item
                    label="Почтовый ящик"
                    name="email"
                    rules={[{type: 'email', required: true}]}
                >
                    <Input/>
                </Form.Item>

                <Form.Item
                    label="Имя пользователя"
                    name="userName"
                >
                    <Input/>
                </Form.Item>

                <Form.Item
                    name="password"
                    label="Пароль"
                    rules={[
                        {
                            required: true,
                            message: 'Пароль обязателен',
                        },
                    ]}
                    hasFeedback
                >
                    <Input.Password/>
                </Form.Item>

                <Form.Item
                    name="confirm"
                    label="Подтверждение пароля"
                    dependencies={['password']}
                    hasFeedback
                    rules={[
                        {
                            required: true,
                            message: 'Подтверждение пароля обязательно',
                        },
                        ({getFieldValue}) => ({
                            validator(rule, value) {
                                if (!value || getFieldValue('password') === value) {
                                    return Promise.resolve();
                                }
                                return Promise.reject('Пароли не совпадают!');
                            },
                        }),
                    ]}
                >
                    <Input.Password/>
                </Form.Item>

                {errors.map(item =>
                    <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
                )}
                {result
                    ?
                    <p style={{textAlign: "center"}}>{result}</p>
                    :
                    <Form.Item {...tailLayout}>
                        <Button type="primary" htmlType="submit" loading={isLoading}>
                            Зарегистрироваться
                        </Button>
                    </Form.Item>
                }
            </Form>
        </>
    )
}
