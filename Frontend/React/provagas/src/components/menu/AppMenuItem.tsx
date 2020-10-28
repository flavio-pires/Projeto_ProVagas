import React from 'react'
import PropTypes from 'prop-types'
import { makeStyles, createStyles } from '@material-ui/core/styles'
// import { SvgIconProps } from '@material-ui/core/SvgIcon'

import List from '@material-ui/core/List'

import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import Divider from '@material-ui/core/Divider'
import Collapse from '@material-ui/core/Collapse'

import AppMenuItemComponent from './AppMenuItemComponent'

// React runtime PropTypes
export const AppMenuItemPropTypes = {
    name: PropTypes.string.isRequired,
    link: PropTypes.string,
    Icon: PropTypes.elementType,
    items: PropTypes.array,
}

// TypeScript compile-time props type, infered from propTypes
// https://dev.to/busypeoples/notes-on-typescript-inferring-react-proptypes-1g88
type AppMenuItemPropTypes = PropTypes.InferProps<typeof AppMenuItemPropTypes>
type AppMenuItemPropsWithoutItems = Omit<AppMenuItemPropTypes, 'items'>

// Improve child items declaration
export type AppMenuItemProps = AppMenuItemPropsWithoutItems & {
    items?: AppMenuItemProps[]
}

const AppMenuItem: React.FC<AppMenuItemProps> = props => {
    const { name, link, Icon, items = [] } = props
    const classes = useStyles()
    const isExpandable = items && items.length > 0
    const [open, setOpen] = React.useState(false)

    function handleClick() {
        setOpen(!open)
    }

    const MenuItemRoot = (
        <AppMenuItemComponent className={classes.menuItem} link={link} onClick={handleClick}>
            {/* Display an icon if any */}
            {!!Icon && (
                <ListItemIcon className={classes.menuItemIcon}>
                    <Icon />
                </ListItemIcon>
            )}

        </AppMenuItemComponent>
    )



    return (
        <>
            {MenuItemRoot}
        </>
    )
}


const useStyles = makeStyles(theme =>
    createStyles({
        menuItem: {
            '&.active': {
                background: 'rgba(0, 0, 0, 0.08)',
                '& .MuiListItemIcon-root': { 
                    color: '#4BB3EE'
                },
                '& .MuiListItemText-root': { 
                    color: '#4BB3EE'
                },

            }
        },
        menuItemIcon: {
            color: '#fff',
            ['@media (max-width:850px)']: {  // eslint-disable-line no-useless-computed-key
                color: '#000000DE',
              }
        },
    }),
)

export default AppMenuItem
