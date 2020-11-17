import { React } from 'react';
import { Button, Tag } from 'antd';
import { FileOutlined } from '@ant-design/icons';
import styled from 'styled-components'

const ApplicantProfile = () => {

    const applications = [
        {
            "id": "1",
            "title": "Junior Software Development Engineer",
            "status": "Accepted for interview"
        },
        {
            "id": "2",
            "title": ".NET Backend Developer Intern",
            "status": "Applied"
        },
    ];

    return (
        <>
            <div style={{ backgroundColor: '#eaedf2', padding: '50px' }}>
                <ProfileHeading>
                    <div>
                        <h1> John Doe </h1>
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
                    {applications.map((app) =>
                        <ApplicationTableRow
                            id={app.id}
                            title={app.title}
                            status={app.status}
                        />
                    )}
                </table>
            </ApplicationsContainer>
        </>
    )
}

const ApplicationTableRow = ({ id, title, status }) => {

    const tagColor = {
        'Applied': 'blue',
        'In review': 'orange',
        'Not accepted': 'red',
        'Accepted for interview': 'green'
    }

    let actions = "";
    if (status === "Accepted for interview") {
        actions = <Button type="primary"> Accept interview  </Button>
    }

    return (
        <tr>
            <td>
                <a href="#"> {title}  </a>
            </td>
            <td>
                <Tag color={tagColor[status]} style={{ fontSize: '16px' }}> {status} </Tag>
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