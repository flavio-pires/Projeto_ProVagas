import React from 'react';
import Header from '../../../components/Header';
import Lista from '../../../components/Lista';
import Menu from '../../../components/MenuLateral';
import InputSearch from '../../../components/InputSearch';
import './style.css';


function Administradores(){
    return(
        <div className="cabeçalho">
            <Header/>
                <InputSearch/>
                <Menu/>
                <Lista/>
        </div>
                
    );
}

export default Administradores;