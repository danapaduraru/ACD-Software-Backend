import { React, Component } from 'react';
import axios from 'axios';
import styled from 'styled-components'

import Header from '../common/Header';

const Interviews = () => {
    return (
        <>
            <Header />
            <InterviewsHeading>
                <h1> Upcoming interviews </h1>
            </InterviewsHeading>
        </>
    )
}

const InterviewsHeading = styled.div`
    width: 100%;
    padding: 60px;
    background-color: #1B2C41;
    color: white;
`

const InterviewsContainer = styled.div`
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

export default Interviews;