import { React } from 'react';
import { Button } from 'antd';
import { FileOutlined } from '@ant-design/icons';
import styled from 'styled-components'

import Header from '../common/Header';
import JobPositionStatusDropdown from './JobPositionStatusDropdown';

const JobPosition = () => {

    const applications = [
        {
            "id": "1",
            "name": "Dana Paduraru",
            "applicationDate": "13/08/2020",
            "status": "Applied",
            "resume": "resume.pdf"
        },
        {
            "id": "2",
            "name": "John Doe",
            "applicationDate": "14/08/2020",
            "status": "In review",
            "resume": "Resume.pdf"
        },
        {
            "id": "3",
            "name": "Johnny Go",
            "applicationDate": "20/08/2020",
            "status": "Accepted for interview",
            "resume": "CV.pdf"
        }
    ];

    return (
        <>
            <Header />
            <div style={{ backgroundColor: '#eaedf2', padding: '50px' }}>
                <JobPositionHeading>
                    <div>
                        <h1> Junior Software Development Engineer </h1>
                        <p> Posted 6 August 2019 </p>
                    </div>
                    <button> Apply now </button>
                </JobPositionHeading>
            </div>
            <JobPositionContainer>
                <h2> Location </h2>
                <p> Iasi, Romania </p>
                <h2> Description </h2>
                <p> Join our tech-focused, data-driven team & watch your Software Developer career soar. Do your best work as a Software Developer & join a community of over 4,500 specialists. Professional development. Work on the best teams. Vault: #1 consulting firm.
                <br></br>
                    <br></br><strong> BASIC QUALIFICATIONS </strong>
                    <br></br>
                    <br></br>· Bachelor's degree in Computer Science;
                <br></br>· Deep understanding of Computer Science fundamentals including software architecture, design patterns, data structures, algorithms and complexity analysis;
                <br></br>· 2+ years professional experience in software development
                <br></br>· Proficiency in at least one modern programming language such as Java, C#, C++, Typescript, Ruby or Python;
                <br></br>· Expertise building scalable, rich, usable web applications;
                <br></br>· Good understanding of big-data technologies and storage types;
                <br></br>· Ability to thrive in fast-paced, dynamic environment;
                <br></br>· Excellent problem solving and troubleshooting skills;
                <br></br>· Knowledge of professional software engineering practices & best practices for the full software development life cycle, including coding standards, code reviews, source control management, build processes, testing at all levels and operations.
                </p>
            </JobPositionContainer>
            {/* Only for employees: */}
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


const ApplicationTableRow = ({ id, name, applicationDate, resume, status }) => {

    // ????? vedem
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