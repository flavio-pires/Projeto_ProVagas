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
import TipoCadastro from './pages/TipoCadastro';
import Login from './pages/Login';
import Vagas from './pages/Vagas';
import DetalheVaga from './pages/DetalheVaga';
import admregister from './pages/CadastroAdm';


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
         <Route path="/cadastro" component={Cadastro}/>
         <Route path="/tipoCadastro" component={TipoCadastro}/>
         <Route path="/login" component={Login}/>
         <Route path="/vagas" component={Vagas}/>
         <Route path="/detalhevaga" component={DetalheVaga}/>
         <Route path="/admregister" component={admregister}/>

        </BrowserRouter>
    );
}

export default Routers;