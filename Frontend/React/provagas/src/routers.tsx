import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import Administradores from './pages/Administrador/Administradores';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>
        <Route path="/administrador" component={Administradores}/>
        
        </BrowserRouter>
    );
}

export default Routers;