import { React, Component } from 'react';
import { Button, Tag } from 'antd';
import { FileOutlined } from '@ant-design/icons';
import axios from 'axios';
import styled from 'styled-components'

import endpoints from '../../Constants';

class ApplicantProfile extends Component {

    state = {
        applications: [],
        applicant: {}
    }

    componentDidMount()
    {
        var id = 'F40D185E-5381-42F0-DDE8-08D8B4BB6E7A';
        axios.get(endpoints.APPLICATIONS_FOR_APPLICANT + id)
            .then (res => {
                this.setState({ applications: res.data});
            });

        axios.get(endpoints.APPLICANT_BY_ID + id)
        .then (res => {
            this.setState({ applicant: res.data});
        });
    }

    render () {
        var fullName = this.state.applicant.firstName + ' ' + this.state.applicant.lastName;

        return (
            <>
                <div style={{ backgroundColor: '#eaedf2', padding: '50px' }}>
                    <ProfileHeading>
                        <div>
                            <h1> {fullName} </h1>
                            <p> Your resume: <a href="#"> resume.pdf </a> </p>
                        </div>
                        <button> Upload new resume </button>
                    </ProfileHeading>
                </div>
                <ApplicationsContainer>
                    <h1> <FileOutlined /> Your Applications </h1>
                    <table>
                        <tr>
                            <th> Job Position </th>
                            <th> Status </th>
                            <th> Action </th>
                        </tr>
                        {this.state.applications.map((app) =>
                            <ApplicationTableRow
                                id={app.id}
                                job={app.jobName}
                                status={app.status}
                            />
                        )}
                    </table>
                </ApplicationsContainer>
            </>
        )
    }
}

const ApplicationTableRow = ({ id, job, status }) => {

    const appStatus = {
        "1": "Pending",
        "2": "Accepted For Interview",
        "3": "In Review ",
        "4": "Finalized"
    }

    const tagColor = {
        'In Review': 'blue',
        'Pending': 'orange',
        'Finalized': 'red',
        'Accepted For Interview': 'green'
    }

    let actions = "";
    if (status === "Accepted For Interview") {
        actions = <Button type="primary"> Accept interview  </Button>
    }

    return (
        <tr>
            <td>
                <a href="#"> {job}  </a>
            </td>
            <td>
                <Tag color={tagColor[appStatus[status]]} style={{ fontSize: '16px' }}> {appStatus[status]} </Tag>
            </td>
            <td>
                {actions}
            </td>
        </tr>
    )
}

const ProfileHeading = styled.div`
    width: 50%;
    margin: 0 auto;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    text-align: center;

    h1 {
        color: #0073A8;
    }

    button {
        height: 30px;
        width: 180px;
        font-size: 100%;
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

export default ApplicantProfile;