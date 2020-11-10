import { React } from 'react';
import styled from 'styled-components'

import Header from '../common/Header';

const JobPosition = () => {

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
            <JobPositionDetails>
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
            </JobPositionDetails>
        </>
    )
}

const JobPositionDetails = styled.div`
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

export default JobPosition;