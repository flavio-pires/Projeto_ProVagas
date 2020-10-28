import React from 'react'
import * as FaIcons from 'react-icons/fa'
import * as AiIcons from 'react-icons/ai'
import * as IoIcons from 'react-icons/io'
import * as MdIcons from 'react-icons/md'

export const SidebarData = [
    {
        title:'Dashboard',
        path: '/dashboarduser',
        icon: <AiIcons.AiFillHome/>,
        cName: 'nav-text'
    },

    {
        title:'Perfil',
        path: '/cadastro',
        icon: <IoIcons.IoMdPerson/>,
        cName: 'nav-text'
    },

    {
        title:'Vagas',
        path: '/',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    }
]
