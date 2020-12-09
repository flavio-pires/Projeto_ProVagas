import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './pages/Home';
import CadastroAdm from './pages/CadastroAdm';
import PerfilAdm from './pages/Administrador/PerfilAdm';
import Admin from './pages/Administrador/Admins';
import EmpresaAdm from './pages/Administrador/EmpresasAdm';
import CandidatosAdm from './pages/Administrador/CandidadosAdm';
import AlertaContrato from './pages/Administrador/AlertaContratos';
import HomeAdm from './pages/Administrador/HomeAdm';

function Routers() {
    return(
        <BrowserRouter>
        <Route path="/" exact component={Home}/>
        <Route path="/administrador" component={HomeAdm}/>
        <Route path="/cadastro" component={CadastroAdm}/>
        <Route path="/dashboaradm/perfil" component={PerfilAdm}/>
        <Route path="/dashboardadm/administrador" component={Admin}/>
        <Route path="/dashboaradm/empresasadm" component={EmpresaAdm}/>
        <Route path="/dashboaradm/candidatosadm" component={CandidatosAdm}/>
        <Route path="/dashboaradm/alertacontratos" component={AlertaContrato}/>
        
        </BrowserRouter>
    );
}

export default Routers;

