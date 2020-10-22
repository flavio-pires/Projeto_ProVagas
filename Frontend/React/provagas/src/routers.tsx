import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Cadastro from './pages/Cadastro';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/cadastro" component={Cadastro}/>
        
        </BrowserRouter>
    );
}

export default Routers;