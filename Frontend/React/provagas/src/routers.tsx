import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import telauser from './pages/DashboardUser'

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/> 
        <Route path="/dashboarduser" component={telauser}/> 
        </BrowserRouter>
    );
}

export default Routers;