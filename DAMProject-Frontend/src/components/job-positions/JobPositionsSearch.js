import { React } from 'react';
import { Input } from 'antd';
import styled from 'styled-components'

const { Search } = Input;

const JobPositionSearch = () => {
    return (
        <JobSearchContainer>
            <SearchContainer>
                <h1> Find jobs </h1>
                <Search
                    placeholder="Search for jobs by title, keyword or location"
                    allowClear
                    enterButton="Search"
                    size="large"
                />
            </SearchContainer>
        </JobSearchContainer>
    )
}


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


export default JobPositionSearch;