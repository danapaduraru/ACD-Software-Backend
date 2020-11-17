import { React } from 'react';
import styled from 'styled-components'

import Header from '../common/Header';
import JobPositionSearch from './JobPositionsSearch';

const Home = () => {

    const jobPositionsList = [
        {
            "id": "1",
            "title": "Junior Software Development Engineer",
            "date": "6 August 2019",
            "location": "Iasi, Romania",
            "description": "Join our tech-focused, data-driven team & watch your Software Developer career soar. Do your best work as a Software Developer & join a community of over 4,500 specialists. Professional development. Work on the best teams. Vault: #1 consulting firm."
        },
        {
            "id": "2",
            "title": ".NET Backend Developer Intern",
            "date": "3 August 2019",
            "location": "Iasi, Romania",
            "description": ".NET is a Microsoft framework that allows developers to create applications, online software, and interfaces. .NET is just one of the frameworks from Microsoft but is the top solution for Windows servers both on local networks and in the cloud."
        },
    ]

    return (
        <>
            <Header />
            <JobPositionSearch />
            <GrayBackground>
                {
                    jobPositionsList.map((jobPosition) => 
                        <JobPosition 
                            title={jobPosition.title}
                            date={jobPosition.date}
                            location={jobPosition.location}
                            description={jobPosition.description}
                        />
                    )
                }
            </GrayBackground>
        </>
    )
}

const JobPosition = ({id, title, date, location, description}) => {
    return (
        <JobPositionContainer>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <h2> {title} </h2>
                <p> Posted {date} </p>
            </div>
            <p> {location} </p>
            <p> {description} </p>
            <a href="/"> Read more </a>
        </JobPositionContainer>
    )
}

const GrayBackground = styled.div`
    background-color: #eaedf2;
    min-height: 100vh;
    padding: 80px;
`

const JobPositionContainer = styled.div`
    background-color: white;
    width: 50%;
    margin: 0 auto;
    margin-bottom: 30px;
    padding: 20px;
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.02), 0 6px 10px 0 rgba(0, 0, 0, 0.10);

    h2, a {
        color: #0073A8;
    }
`
export default Home;