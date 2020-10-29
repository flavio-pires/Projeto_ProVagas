import React from 'react';
import NavBarDashboard from '../../components/menu';


import Conteudo from './dashoardComponente';


function DashboardEmpresa() {
    return (
        <div>
            <div>
                <NavBarDashboard componente={Conteudo()} />
            </div>

        </div>
    );
}

export default DashboardEmpresa;