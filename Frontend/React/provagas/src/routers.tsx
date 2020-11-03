import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import telauser from './pages/DashboardUser';
import perfiluser from './pages/perfilcandidato';
import candidaturas from './pages/Candidaturas';
import dashemp from './pages/dashboardEmpresa';
import perfilemp from './pages/perfilempresa';


function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>         
         <Route path="/dashboarduser" exact component={telauser}/> 
         <Route path="/dashboarduser/perfil" exact component={perfiluser}/> 
         <Route path="/dashboarduser/candidaturas" exact component={candidaturas}/> 
         <Route path="/dashboarempresa" exact component={dashemp}/> 
         <Route path="/dashboarempresa/perfil" exact component={perfilemp}/> 
        </BrowserRouter>
    );
}

export default Routers;