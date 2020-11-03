import React from 'react'
import clsx from 'clsx'
import { makeStyles } from '@material-ui/core/styles'
import CssBaseline from '@material-ui/core/CssBaseline'
import Drawer from '@material-ui/core/Drawer'
import Container from '@material-ui/core/Container'
import AppMenu from './AppMenu'
import { Divider } from '@material-ui/core'

import MenuHeaderBar from '../Header';

interface NavBarProps {
  componente: any
}

const App: React.FC<NavBarProps> = (props) => {
  const classes = useStyles()

  return (
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

        {MenuHeaderBar()}

        <Divider />
        <Container maxWidth="lg" className={classes.container}>
          
          {props.componente}

        </Container>
      </main>
    </div>
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