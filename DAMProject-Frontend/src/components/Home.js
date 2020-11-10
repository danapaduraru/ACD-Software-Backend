import { React } from 'react';

import Header from './common/Header';
import JobPositionSearch from './home/JobPositionsSearch';

function Home() {
    return (
        <>
            <Header />
            <JobPositionSearch />
        </>
    )
}

export default Home;