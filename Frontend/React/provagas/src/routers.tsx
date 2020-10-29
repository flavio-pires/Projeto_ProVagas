import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';
import Administrador from './pages/Administrador';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>
        <Route path="/administrador" component={Administrador}/>
        
        </BrowserRouter>
    );
}

export default Routers;