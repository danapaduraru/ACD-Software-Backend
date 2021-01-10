import { React, Component } from 'react';
import { Button } from 'antd';
import { FileOutlined } from '@ant-design/icons';
import axios from 'axios';
import styled from 'styled-components'
import endpoints from '../../Constants';

import Header from '../common/Header';
import JobPositionStatusDropdown from './JobPositionStatusDropdown';

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

    getApplicantNames() {
        // get the names for each applicant
        var applicants = [];
        this.state.applications.forEach(
            application =>
                axios.get(endpoints.APPLICANT_BY_ID + application.applicantId)
                .then(res => {
                    applicants.push(res.data.firstName + ' ' + res.data.lastName)
                })
        )
       return applicants;
    } 

    // NU MERGE FRATE NU MERGE 

    getFullApplications() {
        var fullApplications = [];
        var names = this.getApplicantNames();

        // var applications = this.state.applications;
        // var i;
        // for(i = 0; i < applications.length; i++) {
        //     var newApplication = {
        //         'date': new Date(applications[i].applicationDate).toDateString(),
        //         'name': names[i],
        //         'status': applications[i].status
        //     }
        //     fullApplications.push(newApplication);
        // }
        return fullApplications;
    }

    render() {
        var applications = this.getFullApplications();
        // console.log("FULL ");
        // console.log(applications);
        var postedDate = new Date(this.state.jobPosition.startDate).toDateString();
        var deadline = new Date(this.state.jobPosition.applicationDeadline).toDateString();

        return (
            <>
                <Header />
                <div style={{ backgroundColor: '#eaedf2', padding: '50px' }}>
                    <JobPositionHeading>
                        <div>
                            <h1> {this.state.jobPosition.position} </h1>
                            <p> Posted <b> {postedDate} </b> </p>
                        </div>
                        <button> Apply now </button>
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
                            {applications.map((app) =>
                                <ApplicationTableRow
                                    id={app.id}
                                    name={app.name}
                                    applicationDate={app.applicationDate}
                                    resume={app.resume}
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

const ApplicationTableRow = ({ id, name, applicationDate, resume, status }) => {

    let actions = "";
    if (status === "In review") {
        actions = <Button> Schedule interview  </Button>
    }

    return (
        <tr>
            <td>
                {name}
            </td>
            <td>
                {applicationDate}
            </td>
            <td>
                <a href="#"> {resume}  </a>
            </td>
            <td>
                <JobPositionStatusDropdown
                    currentStatus={status}
                />
            </td>
            <td>
                {actions}
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