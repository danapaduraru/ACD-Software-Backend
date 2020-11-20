import { Route } from 'react-router-dom'

import './App.css';

import Login from './components/login/Login';
import Home from './components/job-positions/Home';
import JobPosition from './components/job-positions/JobPosition';
import Profile from './components/profile/Profile';
import Interviews from './components/interviews/Interviews';
import CreateInterview from './components/interviews/CreateInterview';

function App() {
  return (
    <>
      <Route exact path="/" component={Home}/>
      <Route exact path="/login" component={Login}/>
      <Route exact path="/jobposition" component={JobPosition}/>
      <Route exact path="/profile" component={Profile}/>
      <Route exact path="/interviews" component={Interviews}/>
      <Route exact path="/createinterview" component={CreateInterview}/>
    </>
  );
}

export default App;
