import { React } from 'react';
import { Menu, Dropdown, message } from 'antd';
import { DownOutlined } from '@ant-design/icons';

const JobPositionStatusDropwdown = ( {currentStatus} ) => {

    const statusList = [
        "Applied",
        "In review",
        "Not accepted",
        "Accepted!"
    ]

    const onClick = ({key}) => {
        message.info(`Status changed to ${key}`);
    };

    const menu = (
        <Menu onClick={onClick}>
            {statusList.map((status) => 
                <Menu.Item key={status}> {status} </Menu.Item>
            )}
        </Menu>
    )

    return (
        <Dropdown overlay={menu}>
            <a className="ant-dropdown-link" onClick={e => e.preventDefault()}>
                {currentStatus} <DownOutlined />
            </a>
        </Dropdown>
    )
}

export default JobPositionStatusDropwdown;