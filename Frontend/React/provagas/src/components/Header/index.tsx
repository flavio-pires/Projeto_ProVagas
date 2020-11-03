import React from 'react';
import './style.css';
import '../../assets/global.css';
import logoSenai from '../../assets/images/logoSenai.png';
import logoProVagas from '../../assets/images/logoProVagas.png';


interface HeaderProps{
}

const Header:React.FC<HeaderProps> = (props) => {
    return(
        <div className="container-principal center">
            <div className="container-principal-header">
            <div className="container-central">
                <nav className="navigation-header">
                    <div className="box-logos">
                        <img className="logoSenai" src={logoSenai} alt=""/>
                        <img className="logoProVagas" src={logoProVagas} alt=""/>
                    </div>
                    <ul className="menu">
                        <li className="menu-link">Vagas</li>
                        <li className="menu-link">Cadastro</li>
                        <li className="menu-link link-login">Login</li>
                    </ul>
                </nav>
            </div>
        </div>
        </div>
    );
} 
export default Header;