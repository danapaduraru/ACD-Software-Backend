import { React, Component } from 'react';
import axios from 'axios';
import { message, DatePicker, TimePicker, InputNumber, Input } from 'antd';
import styled from 'styled-components'
import endpoints from '../../Constants';

import Header from '../common/Header';

const { TextArea } = Input;

class CreateInterview extends Component {

    state = {
        date: '',
        time: '',
        duration: 30,
        details: ''
    }

    scheduleInterview() {
        var requestBody = {
            "date": new Date(this.state.date).toISOString(),
            "details": this.state.details,
            "durationMinutes": this.state.duration,
            "durationHours": 0,
            "personId": "4BB2388A-09FD-4236-DDE9-08D8B4BB6E7A",
            "applicationId": "142EBCBC-BE48-4D8D-08E3-08D8B587A6CE"
        }
        console.log(requestBody);
        axios.post(endpoints.ADD_INTERVIEW, requestBody)
            .then(
                res => {
                    console.log(res);
                    message.success('You successfully scheduled the interview.');
                })
    }

    render () {
        return (
            <>
                <Header />
                <InterviewsHeading>
                    <h1> Schedule a new interview</h1>
                </InterviewsHeading>
                <InterviewsContainer>
                    <h2> Choose a date </h2>
                    <DatePicker onChange={(value) => this.setState({ date: value.toString() })}/>
                    <h2> Choose an hour </h2>
                    <TimePicker onChange={(value) => this.setState({ time: value.toString() })}/>
                    <h2> Interview duration </h2>
                    <InputNumber min={30} max={90} defaultValue={30} onChange={(value) => this.setState({ duration: value })} />
                    <h2> Interview details </h2>
                    <TextArea placeholder="Provide additional details about the interview" allowClear  onChange={(e) => this.setState({ details: e.target.value })}/>
                    <button onClick={() => this.scheduleInterview()}> Schedule interview </button>
                </InterviewsContainer>
            </>
        )
    }
}

const InterviewsHeading = styled.div`
    width: 100%;
    padding: 60px;
    background-color: #1B2C41;
    color: white;
    padding-left: 100px;
`

const InterviewsContainer = styled.div`
    width: 70%;
    margin: 0 auto;
    padding: 20px;

    h1 {
        color: #0073A8;
    }

    h2 {
        margin-top: 25px;
    }

    button {
        margin-top: 40px;
        height: 50px;
        width: 200px;
        font-size: 120%;
        color: #fff;
        background-color: #1890ff;
        border-radius: 2px;
        border: none;
    }

    button:hover {
        background: #389fff;
        cursor: pointer;
    }

    button:focus {
        outline: none;
    }

    button:active {
        transform: translateY(1px);
    }
`

export default CreateInterview;