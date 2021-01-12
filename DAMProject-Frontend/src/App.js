import { Route } from 'react-router-dom'
import { CookiesProvider, useCookies } from 'react-cookie'

import './App.css';

import Login from './components/login/Login';
import Home from './components/job-positions/Home';
import JobPosition from './components/job-positions/JobPosition';
import Profile from './components/profile/Profile';
import Interviews from './components/interviews/Interviews';
import CreateInterview from './components/interviews/CreateInterview';


function App() {
  const [cookies] = useCookies(['user_id']);

  const isLogged = () => {
    return cookies['user_id'] !== undefined && cookies['user_id'] !== '';
  }

  return (
    <>
    {/* <CookiesProvider>
    </CookiesProvider> */}
      <Route exact path="/" component={Home}/>
      <Route exact path="/login" component={Login}/>
      <Route exact path="/JobPositions/:id" component={JobPosition}/>
      <Route exact path="/profile" component={Profile}/>
      <Route exact path="/interviews" component={Interviews}/>
      <Route exact path="/createinterview" component={CreateInterview}/>
    </>
  );
}

export default App;
