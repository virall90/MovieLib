import * as React from "react";
import {Col, Layout, Row} from "antd";
import styles from "./Header.module.css";
import {Link} from "react-router-dom";
import {UserHeaderLayout} from "./UserHeaderLayout/UserHeaderLayout";
import {HomeOutlined} from "@ant-design/icons/lib";

const {Content} = Layout;

const Header = () => {
    return (

        <div className={styles.header}>
            <Layout>
                <Content>
                    <Row>
                        <Col span={8} className={styles.logo}>
                            <Link to={"/"} style={{textAlign: "left", marginLeft: 17}}>
                                <HomeOutlined className={styles.logo_icon}/>
                            </Link>
                        </Col>
                        <Col span={8} className={styles.site}>
                            <div style={{textAlign: "center"}}>
                                <span className={styles.site_name}>Фильмотека</span>
                            </div>
                        </Col>
                        <Col span={8} className={styles.authorization}>
                            <div style={{textAlign: "right", marginRight: 17}}>
                                <UserHeaderLayout/>
                            </div>
                        </Col>
                    </Row>
                </Content>
            </Layout>
        </div>
    );
}
export default Header;
