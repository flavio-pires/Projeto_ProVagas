import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaAdm from '../../../components/ListaAdm';
//import './style.css';
import Navbar from '../../../components/Navbar/navbar';



function Admin(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <InputSearch/>
            <ListaAdm/>
                
        </div>
                
    );
}

export default Admin;