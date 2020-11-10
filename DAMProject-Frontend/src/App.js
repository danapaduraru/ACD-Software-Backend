import { Route } from 'react-router-dom'

import './App.css';

import Home from './components/Home';
import Login from './components/login/Login';
import JobPositionsList from './components/job-positions/JobPositionsList';
import JobPosition from './components/job-positions/JobPosition';

function App() {
  return (
    <>
      <Route exact path="/" component={Home}/>
      <Route exact path="/login" component={Login}/>
      <Route exact path="/jobpositions" component={JobPositionsList}/>
      <Route exact path="/jobposition" component={JobPosition}/>
    </>
  );
}

export default App;
