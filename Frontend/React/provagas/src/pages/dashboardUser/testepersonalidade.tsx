import React from 'react';
import NavBarDashboard from '../../components/menu';


import Conteudo from './TestePersonalidadeComponente';


function testepersonalidade() {
    return (
        <div>
            <div>
                <NavBarDashboard componente={Conteudo()} />
            </div>

        </div>
    );
}

export default testepersonalidade;