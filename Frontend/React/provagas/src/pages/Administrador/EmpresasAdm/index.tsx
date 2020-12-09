import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaEmpresa from '../../../components/ListaEmpresa';
//import './style.css';
import Navbar from '../../../components/Navbar/navbar';



function EmpresaAdm(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <InputSearch/>
            <ListaEmpresa/>                
        </div>
                
    );
}

export default EmpresaAdm;