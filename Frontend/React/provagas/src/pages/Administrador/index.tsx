import React from 'react';
import Header from '../../components/Header';
import Lista from '../../components/Lista';
import Menu from '../../components/MenuLateral';


function Administrador(){
    return(
        <div className="centro">
                <Header/>
                <Menu/>
                <Lista/>
                
        </div>
    );
}

export default Administrador;