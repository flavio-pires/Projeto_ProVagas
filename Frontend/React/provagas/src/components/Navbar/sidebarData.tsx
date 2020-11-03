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
        path: '/dashboarduser/perfil',
        icon: <IoIcons.IoMdPerson/>,
        cName: 'nav-text'
    },

    {
        title:'Candidaturas',
        path: '/dashboarduser/candidaturas',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    }
]

export const SidebarEmpresa = [
    {
        title:'Dashboard',
        path: '/dashboarempresa',
        icon: <AiIcons.AiFillHome/>,
        cName: 'nav-text'
    },

    {
        title:'Perfil',
        path: '/dashboarempresa/perfil',
        icon: <IoIcons.IoMdPerson/>,
        cName: 'nav-text'
    },

    {
        title:'Candidaturas',
        path: '/dashboarempresa/candidaturas',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    }
]
