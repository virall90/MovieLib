import * as React from 'react';
import {Route} from 'react-router';
import Layout from './components/Layout';
import {Home} from './components/Home';

import './custom.css'
import {LoginForm} from "./components/User/LoginForm/LoginForm";
import {RegistrationForm} from "./components/User/RegistrationForm/RegistrationForm";
import {AddEditMovie} from "./components/Movies/AddEditMovie/AddEditMovie";
import {useDispatch} from "react-redux";
import {useEffect, useState} from "react";
import {Spin} from "antd";
import 'antd/es/spin/style/css';
import {initApi} from "./apiClient/initApi";

export const App = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(undefined as string | undefined);

    const init = async () => {
        setIsLoading(true);
        let initError = await initApi();
        if(initError)
            setError(initError);
        setIsLoading(false);
    }

    useEffect(() => {
        init();
    }, []);

    if (isLoading)
        return (
            <div style={{position: "absolute", left: '50%', top: '50%'}}>
                <Spin/>
            </div>);

    if(error)
        return (
            <div style={{position: "absolute", left: '50%', top: '50%'}}>
                <p>{error}</p>
            </div>);
    
    return (
        <Layout>
            <Route exact path='/' component={Home}/>

            <Route path="/AddMovie" component={AddEditMovie}/>
            <Route path="/EditMovie/:movieId" component={AddEditMovie}/>

            <Route path="/Login" component={LoginForm}/>
            <Route path="/Registration" component={RegistrationForm}/>
        </Layout>
    )
};
