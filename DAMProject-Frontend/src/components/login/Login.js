import { React, useState } from 'react';
import { Form, Input, Button } from 'antd'
import {
    MailOutlined,
    LockOutlined,
    UserOutlined
} from '@ant-design/icons';
import styled from 'styled-components'

import Header from '../common/Header';

const Login = () => {
    return (
        <>
            <Header />
            <GrayBackground>
                <DarkOverlayBackground>
                    <ShowForm />
                </DarkOverlayBackground>
            </GrayBackground>

        </>
    )
}

function ShowForm() {

    const [showLogin, setShowLogin] = useState(true);

    return (
        <>
            {
                showLogin ?
                    <FormContainer>
                        <h1> Sign in to your account </h1>

                        {/* EMAIL */}
                        <Form.Item name="email">
                            <Input required
                                prefix={<MailOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                placeholder="Email" />
                        </Form.Item>

                        {/* PASSWORD */}
                        <Form.Item name="password" >
                            <Input required
                                prefix={<LockOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                type="password"
                                placeholder="Password" />
                        </Form.Item>

                        {/* SUBMIT */}
                        <Form.Item>
                            <Button type="primary" htmlType="submit" style={{ width: '100%' }}>
                                Continue
                            </Button>
                        </Form.Item>

                        {/* REGISTER */}
                        <Form.Item>
                            <a href="#" onClick={() => setShowLogin(false)}>
                                Create a new account
                            </a>
                        </Form.Item>
                    </FormContainer>

                    :

                    <FormContainer>
                        <h1> Create a new account </h1>

                        {/* FIRST NAME */}
                        <Form.Item name="firstName">
                            <Input required
                                prefix={<UserOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                placeholder="First Name" />
                        </Form.Item>

                        {/* FIRST NAME */}
                        <Form.Item name="lastName">
                            <Input required
                                prefix={<UserOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                placeholder="Last Name" />
                        </Form.Item>

                        {/* EMAIL */}
                        <Form.Item name="email">
                            <Input required
                                prefix={<MailOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                placeholder="Email" />
                        </Form.Item>

                        {/* PASSWORD */}
                        <Form.Item name="password" >
                            <Input required
                                prefix={<LockOutlined style={{ color: 'rgba(0,0,0,.25' }} />}
                                type="password"
                                placeholder="Password" />
                        </Form.Item>

                        {/* SUBMIT */}
                        <Form.Item>
                            <Button type="primary" htmlType="submit" style={{ width: '100%' }}>
                                Continue
                            </Button>
                        </Form.Item>

                        {/* LOG IN INSTEAD */}
                        <Form.Item>
                            <a href="#" onClick={() => setShowLogin(true)}>
                                Already have an account? Click here to sign in.
                            </a>
                        </Form.Item>
                    </FormContainer>
            }   </>
    )
}

const GrayBackground = styled.div`
    background-color: #eaedf2;
    min-height: 95vh;
`

const DarkOverlayBackground = styled.div`
    background-color: #001529;
    padding-top: 50px;
    height: 250px;
`

const FormContainer = styled.form`
    width: 25%;
    margin: 0 auto;
    padding: 40px;
    background-color: white;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.02), 0 6px 10px 0 rgba(0, 0, 0, 0.05);

    h1 {
        color: #001529;
        margin-bottom: 20px;
        text-align: center;
        font-size: 150%;
    }
`

export default Login;