import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import TipoCadastro from './pages/TipoCadastro';
import Login from './pages/Login';
import Vagas from './pages/Vagas';
import DetalheVaga from './pages/DetalheVaga';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>
        <Route path="/tipoCadastro" component={TipoCadastro}/>
        <Route path="/login" component={Login}/>
        <Route path="/vagas" component={Vagas}/>
        <Route path="/detalhevaga" component={DetalheVaga}/>
        </BrowserRouter>
    );
}

export default Routers;