import {Link} from "react-router-dom";
import styles from "./UserHeaderLayout.module.css";
import {Button, Spin, Tooltip} from "antd";
import * as React from "react";
import {LogoutOutlined} from '@ant-design/icons';
import {useDispatch, useSelector} from 'react-redux'
import {useCallback, useEffect, useState} from "react";
import {userInfoSelector} from "../../../store/User/selectors";
import {getUserInfo, logout} from "../../../store/User/thunks";

export const UserHeaderLayout = () => {
    const [isLoading, setIsLoading] = useState(false);
    const userInfo = useSelector(userInfoSelector);

    const dispatch = useDispatch();
    const logoutCallback = useCallback(
        async () => {
            setIsLoading(true);
            await logout()(dispatch);
            setIsLoading(false);
        },
        [dispatch]);

    const loadData = async () => {
        setIsLoading(true);
        await getUserInfo()(dispatch);
        setIsLoading(false);
    }

    useEffect(() => {
        loadData();
    }, []);

    if (isLoading)
        return (<Spin/>);

    if (userInfo)
        return (
            <>
                <Link to={"/AddMovie"}>
                    <Button type="primary" htmlType="submit" loading={isLoading} style={{marginRight: 17}}>
                        Добавить фильм
                    </Button>
                </Link>
                
                
                <span style={{color: "#fff"}}>{userInfo.userName}</span>
                <Link to={"/"} className={styles.link} onClick={logoutCallback}>
                    <Tooltip title={"Выйти"}>
                        <LogoutOutlined style={{fontSize: "1.2rem", margin: "5px"}}/>
                    </Tooltip>
                </Link>
            </>
        )
    else
        return (
            <>
                <Link to={"/Login"} className={styles.link}>
                    Вход
                </Link>
                <span style={{color: "#fff"}}> / </span>
                <Link to={"/Registration"} className={styles.link}>
                    Регистрация
                </Link>
            </>
        )
}
