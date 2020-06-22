import * as React from "react";
import { Layout } from "antd";
import Top from "./Header/Header";
import styles from "./Layout.module.css";

const { Header, Content } = Layout;

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <Layout>
            <Header className={styles.header}>
                <Top />
            </Header>
            <Layout className={styles.wrapper}>
                <Content className={styles.main}>{props.children}</Content>
            </Layout>
        </Layout>
    </React.Fragment>
);
