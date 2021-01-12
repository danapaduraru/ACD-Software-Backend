import { React, Component } from 'react';
import axios from 'axios';
import { Button } from 'antd';
import styled from 'styled-components'
import endpoints from '../../Constants';

import Header from '../common/Header';

class Interviews extends Component {

    state = {
        interviews: []
    }

    componentDidMount() {
        var personId = '4BB2388A-09FD-4236-DDE9-08D8B4BB6E7A';
        axios.get(endpoints.INTERVIEWS_FOR_PERSON_ID + personId)
            .then(res => {
                console.log(res.data);
                this.setState({ interviews: [res.data]});
            });
    }

    render() {
        return (
            <>
                <Header />
                <InterviewsHeading>
                    <h1> Upcoming Interviews </h1>
                </InterviewsHeading>
                <InterviewsContainer>
                <table>
                    <tr>
                        <th> Applicant Name </th>
                        <th> Date </th>
                        <th> Duration </th>
                        <th> Details </th>
                    </tr>
                    {this.state.interviews.map((interview) =>
                        <InterviewsTableRow
                            id={interview.id}
                            // firstName={interview.firstName}
                            // lastName={interview.lastName}
                            firstName='Dana'
                            lastName='Paduraru'
                            date={interview.date}
                            duration={interview.durationMinutes}
                            details={interview.details}
                        />
                    )}
                </table>
            </InterviewsContainer>
            </>
        )
    }
}

const InterviewsTableRow = ({ id, firstName, lastName, date, duration, details }) => {
    return (
        <tr>
            <td>
                {firstName +  ' ' + lastName}
            </td>
            <td>
                {new Date(date).toDateString()}
            </td>
            <td>
                {duration}
            </td>
            <td>
                {details}
            </td>
        </tr>
    )
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

    table {
        margin-top: 30px;
        border-collapse: collapse;
        font-size: 120%;
        width: 100%;
    }

    th {
        border-bottom: 1px solid #f0f0f0;
        background: #fafafa;
        font-weight: 500;
    }

    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 20px 20px;
    }

    tr:hover {
        background: #f0f0f0;
        transition: background 0.3s;
    }
`

export default Interviews;