import React from 'react'
import { makeStyles, createStyles } from '@material-ui/core/styles'

import List from '@material-ui/core/List'

import logo from '../../assets/images/logoProVagas.png';

import AppMenuItem from './AppMenuItem'
import { Link } from 'react-router-dom'

let token = "empresa"; //adm user empresa


//ARRAY DA SIDEBAR
const appMenuItemsUser = [
  {
    name: 'Dashboard',
    link: '/dashboard'
  },
  {
    name: 'Teste de Personalidade',
    link: '/user/testepersonalidade'
  }
]

const appMenuItemsAdm = [
  {
    name: 'Dashboard',
    link: '/dashboard'
  },
  {
    name: 'Estágios',
    link: '/adm/estagios'
  },
  {
    name: 'Empresas',
    link: '/adm/empresas'
  },
  {
    name: 'Vagas',
    link: '/adm/vagas'
  },
  {
    name: 'Usuários',
    link: '/adm/usuarios'
  }
]

const appMenuItemsEmpresa = [
  {
    name: 'Dashboard',
    link: '/dashboard'
  },
  {
    name: 'Vagas',
    items: [
      {
        name: 'Cadastrar Vaga',
        link: '/empresa/vagas',

      },
    ],
  },
  {
    name: 'Filial',
    items: [
      {
        name: 'Cadastrar Filial',
        link: '/empresa/cadastrarfilial',

      },
    ],
  },
]


const mystyle = {
  width: "186px",
  height: "65px",
  margin: "0 40px 50px 40px"

};

const AppMenu: React.FC = () => {
  const classes = useStyles()

  return (
    <div>
      <Link to="/"><img src={logo} style={mystyle} alt="logo senai"></img></Link>
      <List component="nav" className={classes.appMenu} disablePadding>
        {token === "user" ? appMenuItemsUser.map((item, index) => (<AppMenuItem {...item} key={index} />)) : token === "adm" ? appMenuItemsAdm.map((item, index) => (<AppMenuItem {...item} key={index} />)) : appMenuItemsEmpresa.map((item, index) => (<AppMenuItem {...item} key={index} />))}

        {/* {appMenuItems.map((item, index) => (
          <AppMenuItem {...item} key={index} />
        ))} */}
      </List>
    </div>
  )
}

const drawerWidth = 240

const useStyles = makeStyles(theme =>
  createStyles({
    appMenu: {
      width: '100%',
    },
    navList: {
      width: drawerWidth,
    },
    menuItem: {
      width: drawerWidth,
    },
    menuItemIcon: {
      color: '#97c05c',
    },
  }),
)

export default AppMenu
