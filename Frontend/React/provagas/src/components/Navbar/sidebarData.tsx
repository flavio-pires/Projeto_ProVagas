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
        path: '/dashboardempresa',
        icon: <AiIcons.AiFillHome/>,
        cName: 'nav-text'
    },

    {
        title:'Perfil',
        path: '/dashboardempresa/perfil',
        icon: <IoIcons.IoMdPerson/>,
        cName: 'nav-text'
    },

    {
        title:'Minhas Vagas',
        path: '/dashboardempresa/inscricoes',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    },

    {
        title:'Cadastrar Vagas',
        path: '/dashboardempresa/vaga',
        icon: <FaIcons.FaHandshake/>,
        cName: 'nav-text'
    }
]

export const SidebarAdm = [
    {
        title:'Alerta de Contratos',
        path: '/dashboaradm/alertacontratos',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    },

    {
        title:'EditarPerfil',
        path: '/dashboaradm/perfil/' + 1, // TODO colocar o id do adm logado,
        icon: <IoIcons.IoMdPerson/>,
        cName: 'nav-text'
    },

    {
        title:'Empresas',
        path: '/dashboaradm/empresasadm',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    },

    {
        title:'Candidatos',
        path: '/dashboaradm/candidatosadm',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    },

    {
        title:'Administradores',
        path: '/dashboardadm/administrador',
        icon: <MdIcons.MdWork/>,
        cName: 'nav-text'
    },

]

