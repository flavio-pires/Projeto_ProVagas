import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import telauser from './pages/dashboardUser/dashboard'
import UserTestePersonalidade from './pages/dashboardUser/testepersonalidade';


function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/> 
        <Route path="/dashboarduser" exact component={telauser}/>
        <Route path="/dashboarduser/testepersonalidade"  exact component={UserTestePersonalidade}/>

        </BrowserRouter>
    );
}

export default Routers;