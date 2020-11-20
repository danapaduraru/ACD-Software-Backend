import { React } from 'react';
import { Layout, Menu } from 'antd';

import Header from '../common/Header';

const Interviews = () => {
    return (
        <>
        <Header />
        <div style={{ backgroundColor: '#1B2C41', padding: '50px' }}>
            <h1 style={{ marginLeft: '80px'}}> Upcoming interviews </h1>
        </div>
        </>
    )
}

export default Interviews;