import { React, useState } from 'react';
import { Input, Button, DatePicker, TimePicker, Slider, InputNumber } from 'antd';
import styled from 'styled-components'

import Header from '../common/Header';

const { TextArea } = Input;

const CreateInterview = () => {

    const [duration, setDuration] = useState(0);

    function onChangeDate(date, dateString) {
        console.log(dateString);
    }

    function onChangeTime(time, timeString) {
        console.log(timeString);
    }

    return (
        <>
            <Header />
            <div style={{ backgroundColor: '#1B2C41', padding: '50px' }}>
                <h1 style={{ marginLeft: '80px' }}> Create a new interview </h1>
            </div>
            <NewInterviewContainer>
                <div className="container">
                    <h2> Schedule an interview with John Doe for .NET Developer </h2>
                    <span> Choose a date and provide details about the interview. </span>
                    <p> Date </p><DatePicker onChange={onChangeDate} />
                    <p> Time </p><TimePicker onChange={onChangeTime} />
                    <p> Duration </p>
                    <div className="slider">
                        <Slider
                            min={1}
                            max={180}
                            onChange={setDuration}
                            value={typeof duration === 'number' ? duration : 0}
                        />
                    </div>
                    <InputNumber
                        min={1}
                        max={180}
                        style={{ margin: '0 16px' }}
                        value={duration}
                        onChange={setDuration}
                    />
                    <span> minutes </span>
                    <p> Additional details </p>
                    <TextArea
                        placeholder="Provide additional details about the interview and where it will take place."
                        autoSize={{ minRows: 3, maxRows: 6 }}
                    />
                    <Button type="primary" classname="btn-submit"> Schedule interview </Button>
                </div>
            </NewInterviewContainer>
        </>
    )
}

const NewInterviewContainer = styled.div`
    background-color: #eaedf2;
    ${'' /* padding: 50px 300px 50px 300px; */}
    padding: 50px;

    .container {
        width: 60%;
        margin: 0 auto;
        font-size: 120%;
        min-height: 70vh;
    }

    p {
        margin-top: 25px;
        margin-bottom: 10px;
        font-weight: 600;
    }

    .slider {
        width: 500px;
    }

    .ant-btn {
        margin: 30px 80px 0px 0px;
        font-size: 18px;
        padding: 10px 12px 40px 12px;
    }

`

export default CreateInterview;