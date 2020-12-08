import React from 'react';
import Lista from '../../../components/Lista';
import InputSearch from '../../../components/InputSearch';
//import './style.css';
import Navbar from '../../../components/Navbar/navbar';



function Administradores(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <InputSearch/>
            <Lista/>
                
        </div>
                
    );
}

export default Administradores;