import React from 'react';
import './style.css';
import '../../assets/global.css';
import logoSenai from '../../assets/images/logoSenai.png';
import logoProVagas from '../../assets/images/logoProVagas.png';
import { Link } from 'react-router-dom';


interface HeaderProps{
}

const logado:React.FC<HeaderProps> = (props) => {
    return(
        <div className="container-principal center">
            <div className="container-principal-h">
            <div className="container-central">
                <nav className="navigation-header">
                <div className="box-logos">
                        <Link to="/"><img className="LOGO" src={logoSenai} alt="Logo do Senai" /></Link>
                        <Link to="/"><img className="logoProVagas" src={logoProVagas} alt="Logo ProVagas"/></Link>
                    </div>
                    <ul className="menu">
                        <li><Link to="/vagas" className="menu-link">Vagas</Link></li>
                        <li><Link to="/" className="menu-link link-login">Logout</Link></li>
                    </ul>
                </nav>
            </div>
        </div>
        </div>
    );
} 
export default logado;