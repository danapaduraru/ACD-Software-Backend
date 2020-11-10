import { Route } from 'react-router-dom'

import './App.css';

import Login from './components/login/Login';
import Home from './components/job-positions/Home';
import JobPosition from './components/job-positions/JobPosition';

function App() {
  return (
    <>
      <Route exact path="/" component={Home}/>
      <Route exact path="/login" component={Login}/>
      <Route exact path="/jobposition" component={JobPosition}/>
    </>
  );
}

export default App;
