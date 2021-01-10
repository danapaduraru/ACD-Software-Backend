import { React, Component } from 'react';
import { Link } from 'react-router-dom';
import { message, Button, Search } from 'antd';
import { FileOutlined } from '@ant-design/icons';
import axios from 'axios';
import styled from 'styled-components'
import endpoints from '../../Constants';

import Header from '../common/Header';

class JobPosition extends Component {

    state = {
        jobPosition: {},
        applications: [],
    };

    componentDidMount() {
        var jobID = this.props.location.pathname.substring(this.props.location.pathname.length - 36);
        axios.get(endpoints.JOB_POSITION_BY_ID + jobID)
            .then(res => {
                this.setState({ jobPosition: res.data });
            });

        axios.get(endpoints.APPLICATIONS_FOR_JOB_POSITION + jobID)
        .then(res => {
            this.setState({ applications: res.data });
        });
    }

    saveApplication() {
        var applicantID = "F40D185E-5381-42F0-DDE8-08D8B4BB6E7A";
        var jobID = this.props.location.pathname.substring(this.props.location.pathname.length - 36);

        var requestBody = {
            "jobPositionId": jobID,
            "applicantId": applicantID
        }

        axios.post(endpoints.ADD_APPLICATION, requestBody)
            .then(
                res => {
                    console.log(res);
                    message.success('You successfully applied to this job position.');
                })
    }

    render() {
        var postedDate = new Date(this.state.jobPosition.startDate).toDateString();
        var deadline = new Date(this.state.jobPosition.applicationDeadline).toDateString();
        console.log(this.state.applications);
        return (
            <>
                <Header />
                <div style={{ backgroundColor: '#eaedf2', padding: '50px' }}>
                    <JobPositionHeading>
                        <div>
                            <h1> {this.state.jobPosition.position} </h1>
                            <p> Posted <b> {postedDate} </b> </p>
                        </div>
                        <button onClick={() => this.saveApplication()}> Apply now </button>
                    </JobPositionHeading>
                </div>
                <JobPositionContainer>
                    <p> <b> Please apply until {deadline}. </b> </p>
                    <h2> Level </h2>
                    <p> {this.state.jobPosition.level} </p>
                    <h2> Description </h2>
                    <p> {this.state.jobPosition.description} </p>
                </JobPositionContainer>
                
                <JobPositionContainer>
                    <ApplicationsContainer>
                        <h1> <FileOutlined /> Applications </h1>
                        <table>
                            <tr>
                                <th> Name </th>
                                <th> Application date </th>
                                <th> Resume </th>
                                <th> Change status </th>
                                <th> Actions </th>
                            </tr>
                            {this.state.applications.map((app) =>
                                <ApplicationTableRow
                                    id={app.id}
                                    firstName={app.applicantFirstName}
                                    lastName={app.applicantLastName}
                                    applicationDate={app.applicationDate}
                                    status={app.status}
                                />
                            )}
                        </table>
                    </ApplicationsContainer>
                </JobPositionContainer>
            </>
        )
    }
}

var appStatus = {
    "1": "Pending",
    "2": "Accepted For Interview",
    "3": "In Review ",
    "4": "Finalized"
}

var appStatusColor = {
    "1": "green",
    "2": "blue",
    "3": "red",
    "4": "gray"
}

const ApplicationTableRow = ({ id, firstName, lastName, applicationDate, status }) => {

    var redirect = "/createinterview";
    return (
        <tr>
            <td>
                {firstName + ' ' + lastName}
            </td>
            <td>
                {new Date(applicationDate).toDateString()}
            </td>
            <td>
                <a href="#"> resume.pdf  </a>
            </td>
            <td>
                <b><p style={{ color: appStatusColor[status] }}> {appStatus[status]} </p></b>
            </td>
            <td>
                <Button> 
                    <Link to={redirect}>
                    Schedule interview
                    </Link>  
                </Button>
            </td>
        </tr>
    )
}

const JobPositionContainer = styled.div`
    width: 50%;
    margin: 0 auto;
    padding: 20px;
    font-size: 110%;
`

const JobPositionHeading = styled.div`
    width: 50%;
    margin: 0 auto;
    display: flex;
    justify-content: space-between;
    align-items: center;

    h1 {
        color: #0073A8;
    }

    button {
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

const ApplicationsContainer = styled.div`
    margin-bottom: 50px;

    h1 {
        color: #0073A8;
        font-size: 150%;
    }

    table {
        margin-top: 30px;
        border-collapse: collapse;
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

export default JobPosition;