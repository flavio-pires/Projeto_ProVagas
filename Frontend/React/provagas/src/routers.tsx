import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
//Importações das páginas dashboard do usuario
import telauser from './pages/DashboardUser/dashboardhome';
import perfiluser from './pages/DashboardUser/perfilcandidato';
import candidaturas from './pages/DashboardUser/Candidaturas';
//Importações das páginas dashboard da empresa
import dashemp from './pages/dashboardEmpresa/dashboardempresahome';
import perfilemp from './pages/dashboardEmpresa/perfilempresa';
import cadasvaga from './pages/dashboardEmpresa/cadastrarvaga';
import vagasempresa from './pages/dashboardEmpresa/MinhasVagas';
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

        {/* Dashboard Candidato */}
         <Route path="/dashboarduser" exact component={telauser}/> 
         <Route path="/dashboarduser/perfil" exact component={perfiluser}/> 
         <Route path="/dashboarduser/candidaturas" exact component={candidaturas}/> 

         {/* Dashboard Empresa */}
         <Route path="/dashboardempresa" exact component={dashemp}/> 
         <Route path="/dashboardempresa/perfil" exact component={perfilemp}/> 
         <Route path="/dashboardempresa/vaga" exact component={cadasvaga}/>
         <Route path="/dashboardempresa/minhasvagas" exact component={vagasempresa}/>
         
          {/* Cadastro Usuario/Empresa/Administrador */}
         <Route path="/register" exact component={eps}/> 
         <Route path="/cadastro" component={Cadastro}/>
         <Route path="/tipoCadastro" component={TipoCadastro}/>
         <Route path="/admregister" component={admregister}/>

         <Route path="/login" component={Login}/>
         <Route path="/vagas" component={Vagas}/>
         <Route path="/detalhevaga/:id" component={DetalheVaga}/>

        </BrowserRouter>
    );
}

export default Routers;