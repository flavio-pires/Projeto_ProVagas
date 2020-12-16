import React, { useState } from 'react';
import { Link } from 'react-router-dom'
import { SidebarEmpresa, SidebarData, SidebarAdm } from './sidebarData'
import './style.css'
import Header from '../Header';
import { parseJWT } from '../../services/auth';

export default function Navbar() {
    const [sidebar, setSidebar] = useState(false)

    const showSidebar = () => setSidebar(!sidebar)

    const sidebarnav = () => {
        const token = localStorage.getItem('provagas-chave-autenticacao');

        if (parseJWT().Role === "Candidato") {
            return (
                <aside>
                    <div className='navbar'>
                        <Header />
                    </div>
                    <nav className='nav-menu'>
                        <ul className='nav-menu-items'>
                            {SidebarData.map((item, index) => {
                                return (
                                    <li key={index} className={item.cName}>
                                        <Link to={item.path}>
                                            {item.icon}
                                            <span>{item.title}</span>
                                        </Link>
                                    </li>
                                )
                            })}
                        </ul>
                    </nav>
                </aside>
            );

        }
        else {

            if (parseJWT().Role === "Empresa") {
                return (
                    <aside>
                        <div className='navbar'>
                            <Header />
                        </div>
                        <nav className='nav-menu'>
                            <ul className='nav-menu-items'>
                                {SidebarEmpresa.map((item, index) => {
                                    return (
                                        <li key={index} className={item.cName}>
                                            <Link to={item.path}>
                                                {item.icon}
                                                <span>{item.title}</span>
                                            </Link>
                                        </li>
                                    )
                                })}
                            </ul>
                        </nav>
                    </aside>
                );
            }
            else {
                if (parseJWT().Role === "Administrador") {
                    return (
                        <aside>
                            <div className='navbar'>
                                <Header />
                            </div>
                            <nav className='nav-menu'>
                                <ul className='nav-menu-items'>
                                    {SidebarAdm.map((item, index) => {
                                        return (
                                            <li key={index} className={item.cName}>
                                                <Link to={item.path}>
                                                    {item.icon}
                                                    <span>{item.title}</span>
                                                </Link>
                                            </li>
                                        )
                                    })}
                                </ul>
                            </nav>
                        </aside>
                    );
                }

            }
        }

    }

    return (
        <aside>
            {sidebarnav()}
        </aside>
    )
}
