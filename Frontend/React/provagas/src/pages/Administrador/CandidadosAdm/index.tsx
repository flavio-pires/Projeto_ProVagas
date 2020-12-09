import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaCandidato from '../../../components/ListaCandidato';
//import './style.css';
import Navbar from '../../../components/Navbar/navbar';



function CandidatosAdm(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <InputSearch/>
            <ListaCandidato/>                
        </div>
                
    );
}

export default CandidatosAdm;