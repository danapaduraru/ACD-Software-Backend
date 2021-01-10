import { React, Component } from 'react';
import axios from 'axios';
import styled from 'styled-components'

import Header from '../common/Header';
import JobPositionSearch from './JobPositionsSearch';
import endpoints from '../../Constants';

class Home extends Component {
    state = {
        jobPositionsList: [],
    };

    componentDidMount()
    {
        axios.get(endpoints.JOB_POSITIONS)
            .then (res => {
                console.log(res);
                this.setState({ jobPositionsList: res.data});
            });
    }
    
    render () {
        return (
            <>
                <Header />
                <JobPositionSearch />
                <GrayBackground>
                    { this.state.jobPositionsList.map((jobPosition) => 
                        <JobPosition 
                            id = {jobPosition.jobPositionId}
                            status = {jobPosition.status}
                            title={jobPosition.position}
                            deadlinedate={jobPosition.applicationDeadline}
                            startdate={jobPosition.startDate}
                            level={jobPosition.level}
                            description={jobPosition.description}
                        />
                        )
                    }
                </GrayBackground>
            </>
        )
    }
}

var dictStatus = {
    "1" : "Open",
    "2" : "Soon",
    "3" : "Closed",
    "4" : "Cancelled"
}

var dictStatusColor = {
    "1" : "green",
    "2" : "blue",
    "3" : "red",
    "4" : "gray"
}

const JobPosition = ({id, status, title, deadlinedate, startdate, level, description}) => {
    var redirect = "/JobPositions/" + id;

    var formattedDeadlineDate = new Date(deadlinedate).toDateString();

    var formattedStartDate = new Date(startdate).toDateString();

    return (
        <JobPositionContainer>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <h2> {title} ({level}) </h2>
                <p> <b>Apply Until: </b> {formattedDeadlineDate} </p>
            </div>
            <b><p style = {{color: dictStatusColor[status]}}> {dictStatus[status]} </p></b>
            <p> {description} </p>
            
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <b><a href={redirect}> Read more </a></b>
                <p> <b>Start Date:</b> {formattedStartDate} </p>
            </div>
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