import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import telauser from './pages/DashboardUser';
import perfiluser from './pages/perfilcandidato';
import candidaturas from './pages/Candidaturas';
import dashemp from './pages/dashboardEmpresa';
import perfilemp from './pages/perfilempresa';
import cadasvaga from './pages/cadastrarvaga';
import eps from './pages/RegisterEmp';


function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>       
         <Route path="/dashboarduser" exact component={telauser}/> 
         <Route path="/dashboarduser/perfil" exact component={perfiluser}/> 
         <Route path="/dashboarduser/candidaturas" exact component={candidaturas}/> 
         <Route path="/dashboarempresa" exact component={dashemp}/> 
         <Route path="/dashboarempresa/perfil" exact component={perfilemp}/> 
         <Route path="/dashboarempresa/vaga" exact component={cadasvaga}/> 
         <Route path="/register" exact component={eps}/> 
        </BrowserRouter>
    );
}

export default Routers;