import { React } from 'react';
import { Link } from 'react-router-dom'
import { Layout, Menu } from 'antd';
import {
    UserOutlined,
    BulbOutlined,
    CommentOutlined
} from '@ant-design/icons';

const { Header } = Layout;

const ACDHeader = () => {
    return (
        <Header className="header">
            <Menu theme="dark" mode="horizontal">
                {/* LOGO */}
                <BulbOutlined style={{ fontSize: '20px', color: 'white', marginRight: '20px' }} />
                <Link to="/" className="my-logo"> ACD Software </Link>

                <Menu.Item key="2" icon={<UserOutlined />}>
                    <Link to="/profile"> Profile </Link>
                </Menu.Item>
                <Menu.Item key="4" icon={<CommentOutlined />}>
                <Link to="/interviews"> Interviews </Link>
                </Menu.Item>
                <Menu.Item key="5" icon={<UserOutlined />}>
                    <Link to="/login"> Login </Link>
                </Menu.Item>
            </Menu>
        </Header>
    )
}

export default ACDHeader;