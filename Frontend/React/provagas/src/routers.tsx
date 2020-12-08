import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import Administradores from './pages/Administrador/Administradores';
import CadastroAdm from './pages/CadastroAdm';
import PerfilAdm from './pages/Administrador/PerfilAdm';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/administrador" component={Administradores}/>
        <Route path="/cadastro" component={CadastroAdm}/>
        <Route path="/dashboaradm/perfil" component={PerfilAdm}/>
        
        </BrowserRouter>
    );
}

export default Routers;