import React, { useState } from 'react';
import {Link} from 'react-router-dom'
import {SidebarEmpresa} from './sidebarData'
import './style.css'
import Header from '../logado';

export default function Navbar() {
const [sidebar, setSidebar] = useState(false)

const showSidebar = () => setSidebar(!sidebar)

    return (
        <aside>
        <div className='navbar'>
            <Header/>
        </div>
            <nav  className='nav-menu'>
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
    )
}