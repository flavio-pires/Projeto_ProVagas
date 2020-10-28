import React from 'react'
import clsx from 'clsx'
import { Link } from 'react-router-dom'
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles'
import CssBaseline from '@material-ui/core/CssBaseline'
import Drawer from '@material-ui/core/Drawer'
import Container from '@material-ui/core/Container'
import AppMenu from './AppMenu'
import { ClickAwayListener, Divider, Grow, Icon, IconButton, List, ListItem, ListItemIcon, ListItemText, MenuItem, MenuList, Paper, Popper } from '@material-ui/core'
import AppMenuItem from './AppMenuItem'
import Button from '../Button'
import Vagas from '../../pages/DashboardUser';
import Home from '../../pages/Home'



const App: React.FC = () => {
  const classes = useStyles()

  let token = "user";
  //MENU HAMBURGUER

  const [open, setOpen] = React.useState(false);


  type Anchor = 'top' | 'left' | 'bottom' | 'right';

  const [state, setState] = React.useState({
    top: false,
    left: false,
    bottom: false,
    right: false,
  });

  const toggleDrawer = (anchor: Anchor, open: boolean) => (
    event: React.KeyboardEvent | React.MouseEvent,
  ) => {
    if (
      event.type === 'keydown' &&
      ((event as React.KeyboardEvent).key === 'Tab' ||
        (event as React.KeyboardEvent).key === 'Shift')
    ) {
      return;
    }

    setState({ ...state, [anchor]: open });
  };


  const stilos = makeStyles({
    list: {
      width: 250,
    },
    fullList: {
      width: 'auto',
    },
  });

  const classeMenuHamb = stilos()

  const outrosStilos = makeStyles((theme: Theme) =>
    createStyles({
      paper: {
        marginTop: 10,
        marginRight: 10
      },
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
        color: '#fff',
      },
    }),
  );

  const classe = outrosStilos();

  const handleToggle = () => {
    setOpen((prevOpen) => !prevOpen);
  };

  const handleClose = (event: React.MouseEvent<EventTarget>) => {
    if (anchorRef.current && anchorRef.current.contains(event.target as HTMLElement)) {
      return;
    }

    setOpen(false);
  };

  function handleListKeyDown(event: React.KeyboardEvent) {
    if (event.key === 'Tab') {
      event.preventDefault();
      setOpen(false);
    }
  }

  //ARRAY DO MENU HAMBUGUER
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
          link: '/company/cadastrarfilial',

        },
      ],
    },
  ]

  const list = (anchor: Anchor) => (
    <div
      className={clsx(classeMenuHamb.list, {
        [classeMenuHamb.fullList]: anchor === 'top' || anchor === 'bottom',
      })}
      role="presentation"
      onClick={toggleDrawer(anchor, true)}
      onKeyDown={toggleDrawer(anchor, true)}
    >
      <List>
        {['Home', 'Perfil', 'Configurações'].map((text, index) => (
          <Link className="link" to='/configuracoes'><ListItem button key={text}>
            {/* <ListItemIcon>{index === 0 ? <HomeOutlined /> : <ExitToAppOutlined />}</ListItemIcon> */}
            <ListItemText primary={text} />
          </ListItem>
          </Link>
        ))}
      </List>
      <Divider />
      <List>
        <List component="nav" className={classe.appMenu} disablePadding>
          {token === "user" ? appMenuItemsUser.map((item, index) => (<AppMenuItem {...item} key={index} />)) : token === "adm" ? appMenuItemsAdm.map((item, index) => (<AppMenuItem {...item} key={index} />)) : appMenuItemsEmpresa.map((item, index) => (<AppMenuItem {...item} key={index} />))}
          {/* {appMenuItems.map((item, index) => (
                      <AppMenuItem {...item} key={index} />
                  ))} */}
        </List>
      </List>
      <Divider />
      <List>
        {['Sair'].map((text, index) => (
          <ListItem button key={text}>
            <ListItemText primary={text} />
          </ListItem>
        ))}
      </List>
    </div>
  );

  const estiloNotification = {
    width: '35px',
    height: '35px'
  };

  const estiloHam = {
    width: '50px',
    height: '50px',
    color: '#000000DE'
  };

  const estiloDropDown = {
    color: '#000000DE'
  };

  const anchorRef = React.useRef<HTMLButtonElement>(null);

  const navbar = () => {

    let nome = "Hebert Richard";

    if (token === "user") {
      return (
        <div className="rightDashboard">
          

          <div className="modalUserDashboard">
            <p className="textoDashboard">{nome}</p>
            <div className="dropdownDashboard">
              {/* <img src={dropdown} alt="menu dropdown" onClick={handleToggle} ref={anchorRef} /> */}
              {/* SETA Q DESCE MENU */}
             

              <Popper open={open} anchorEl={anchorRef.current} role={undefined} transition disablePortal className={classe.paper}>
                {({ TransitionProps, placement }) => (
                  <Grow
                    {...TransitionProps}
                    style={{ transformOrigin: placement === 'bottom' ? 'center top' : 'center bottom' }}
                  >
                    <Paper>
                      <ClickAwayListener onClickAway={handleClose}>
                        <MenuList autoFocusItem={open} id="menu-list-grow" onKeyDown={handleListKeyDown}>
                          <Link className="link" to="/perfil"><MenuItem onClick={handleClose}>Perfil</MenuItem></Link>
                          <Link to="/configuracoes" className="link"><MenuItem onClick={handleClose}>Configurações</MenuItem></Link>
                          <Link to="/" className="link"><MenuItem onClick={handleClose}>Sair</MenuItem></Link>
                        </MenuList>
                      </ClickAwayListener>
                    </Paper>
                  </Grow>
                )}
              </Popper>
            </div>
          </div>

          {(['right'] as Anchor[]).map((anchor) => (
            <React.Fragment key={anchor}>
              <Drawer anchor={anchor} open={state[anchor]} onClose={toggleDrawer(anchor, false)}>
                {list(anchor)}
              </Drawer>
            </React.Fragment>
          ))}
        </div>
      )

    }
    else {
      return (
        <div className="rightDashboard">
          <div className="botaoNavDashboard">
            {/* <Link to="/"><Button className="button" type="button" value="Dashboard" /></Link> */}
          </div>

          <div className="modalUserDashboard">
            <p className="textoDashboard">{nome}</p>
            <div className="dropdown">
              {/* <img src={dropdown} alt="menu dropdown" onClick={handleToggle} ref={anchorRef} /> */}
              

              <Popper open={open} anchorEl={anchorRef.current} role={undefined} transition disablePortal className={classe.paper}>
                {({ TransitionProps, placement }) => (
                  <Grow
                    {...TransitionProps}
                    style={{ transformOrigin: placement === 'bottom' ? 'center top' : 'center bottom' }}
                  >
                    <Paper>
                      <ClickAwayListener onClickAway={handleClose}>
                        <MenuList autoFocusItem={open} id="menu-list-grow" onKeyDown={handleListKeyDown}>
                          <Link className="link" to="/perfil"><MenuItem onClick={handleClose}>Perfil</MenuItem></Link>
                          <Link to="/configuracoes" className="link"><MenuItem onClick={handleClose}>Configurações</MenuItem></Link>
                          <Link to="/" className="link"><MenuItem onClick={handleClose}>Sair</MenuItem></Link>
                        </MenuList>
                      </ClickAwayListener>
                    </Paper>
                  </Grow>
                )}
              </Popper>
            </div>
          </div>

          {(['right'] as Anchor[]).map((anchor) => (
            <React.Fragment key={anchor}>
              <Drawer anchor={anchor} open={state[anchor]} onClose={toggleDrawer(anchor, false)}>
                {list(anchor)}
              </Drawer>
            </React.Fragment>
          ))}
        </div>
      )
    }
  }



  // let history = useHistory();


  return (
    // <BrowserRouter>
    <div className={clsx('App', classes.root)}>
      <CssBaseline />
      <Drawer className="response"
        variant="permanent"
        classes={{
          paper: classes.drawerPaper,
        }}
      >
        <AppMenu />
      </Drawer>
      <main className={classes.content}>

        {navbar()}

        <Divider />
        <Container maxWidth="lg" className={classes.container}>
          {window.location.href === 'http://localhost:3000/DashboardUser' ? Home() : Vagas()}



          {/* FAZER IF  {history.push('/a')}; */}

        </Container>
      </main>
    </div>
    // </BrowserRouter>
  )
}

const drawerWidth = 280

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
  },
  drawerPaper: {
    position: 'relative',
    whiteSpace: 'nowrap',
    width: drawerWidth,
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4),
    //COR BACKGBROUND SIDEBAR
    background: '#1F1F20',
    // COR LETRA SIDEBAR
    color: '#fff',
  },
  content: {
    flexGrow: 1,
    height: '100vh',
    overflow: 'auto',
  },
  container: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4),

  },
}))

export default App