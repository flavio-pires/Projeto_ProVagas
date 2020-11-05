import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import TipoCadastro from './pages/TipoCadastro';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>
        <Route path="/tipoCadastro" component={TipoCadastro}/>
        </BrowserRouter>
    );
}

export default Routers;