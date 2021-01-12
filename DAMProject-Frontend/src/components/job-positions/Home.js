import { React, Component } from 'react';
import { Input } from 'antd';
import axios from 'axios';
import styled from 'styled-components'

import Header from '../common/Header';
import endpoints from '../../Constants';

const { Search } = Input;

class Home extends Component {
    state = {
        jobPositionsList: [],
        searchList: [],
    };

    componentDidMount() {
        axios.get(endpoints.JOB_POSITIONS)
            .then(res => {
                this.setState({ jobPositionsList: res.data });
                this.setState({ searchList: res.data });
            });
    }

    searchOnChange(e) {
        var filter = e.target.value;
        var list = this.state.searchList.filter(function (item) {
            return item.position.includes(filter);
        });
        if (filter === '') {
            this.setState({ searchList: this.state.jobPositionsList });
        }
        else {
            this.setState({ searchList: list });
        }
    }

    render() {
        return (
            <>
                <Header />
                <JobSearchContainer>
                    <SearchContainer>
                        <h1> Find jobs </h1>
                        <Search
                            placeholder="Search for jobs by title, keyword or location"
                            allowClear
                            enterButton="Search"
                            size="large"
                            onChange={(e) => this.searchOnChange(e)}
                        />
                    </SearchContainer>
                </JobSearchContainer>
                <GrayBackground>
                    {this.state.searchList.map((jobPosition) =>
                        <JobPosition
                            id={jobPosition.jobPositionId}
                            status={jobPosition.status}
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

const dictStatus = {
    "1": "Open",
    "2": "Soon",
    "3": "Closed",
    "4": "Cancelled"
}

const dictStatusColor = {
    "1": "green",
    "2": "blue",
    "3": "red",
    "4": "gray"
}

const JobPosition = ({ id, status, title, deadlinedate, startdate, level, description }) => {
    var redirect = "/JobPositions/" + id;

    var formattedDeadlineDate = new Date(deadlinedate).toDateString();

    var formattedStartDate = new Date(startdate).toDateString();

    return (
        <JobPositionContainer>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <h2> {title} ({level}) </h2>
                <p> <b>Apply Until: </b> {formattedDeadlineDate} </p>
            </div>
            <b><p style={{ color: dictStatusColor[status] }}> {dictStatus[status]} </p></b>
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

const JobSearchContainer = styled.div`
    width: 100%;
    padding: 80px;
    background-color: #1B2C41;
    color: white;
    font-size: 130%;
`

const SearchContainer = styled.div`
    width: 60%;
    margin: 0 auto;
`

export default Home;