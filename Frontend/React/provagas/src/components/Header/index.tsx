import React, { useEffect, useState } from 'react';
import './style.css';
import '../../assets/global.css';
import logoSenai from '../../assets/images/logoSenai.png';
import logoProVagas from '../../assets/images/logoProVagas.png';
import { useHistory, Link } from 'react-router-dom';




const Header = () => {
    const [Cargo, setCargo] = useState('');

    const refresh = () => {
        fetch('http://localhost:5000/api/Usuarios/BuscarPorId', {
          method: 'GET',
          headers: {
            authorization: 'Bearer ' + localStorage.getItem('token-filmes')
          }
        })
          .then(response => response.json())
          .then(dados => {
            setCargo(dados.permissao);
          })
          .catch(err => console.error(err));
      }
    
      useEffect(() => {
        refresh();
      });
      
      let history = useHistory();
    
      //criando a função logout, removendo o token do localStorage e chamando a página do usuário deslogado
      const logout = () => {
        localStorage.removeItem('token-provagas');
        history.push('/');
      }
      // criando a função menu() com a estrutura condicional que retornará o menu para usuários logados e deslogado
      const menu = () => {
        // a variável token recebe o conteúdo do local storage
        const token = localStorage.getItem('token-provagas');
    
        //se o valor de token estiver indefinido ou nulo, chama o menu deslogado, se não chama o menu para quando o usuário estiver logado
        if (token === undefined || token === null) {
          return (
            <div className="Nav">
              <a><Link to="/" className="link">Home</Link></a>
              <a><Link to="/login" className="link">Login</Link></a>
              <a><Link to="/cadastro" className="link">Cadastro</Link></a>
            </div>
          )
        } else if (Cargo == 'Empresa') {
          return (
            <div className="Nav">
              <a><Link to="/" className="link">Home</Link></a>
              <a><Link to="/perfil" className="link">Perfil</Link></a>
              <a><Link to="/genero" className="link">Genero</Link></a>
              <a><Link to="/filmes" className="link">Filmes</Link></a>
              <a><Link to='' onClick={(event) => {
                event.preventDefault();
                logout();
              }}>Logout</Link></a> <br />
            </div>
          )
        }
        else if (Cargo == 'Comum') {
          return (
            <div className="Nav">
              <a><Link to="/" className="link">Home</Link></a>
              <a><Link to="/vagas" className="link">Vagas</Link></a>
              <a><Link to="/resgister" className="link">Cadastrar</Link></a>
              <a><Link to="/login" className="link">Login</Link></a>
              <a><Link to='' onClick={(event) => {
                event.preventDefault();
                logout();
              }}>Logout</Link></a> <br />
            </div>
          )
        }
      }
    return(
        <div className="container-principal center">
            <div className="container-principal-header">
            <div className="container-central">
                <nav className="navigation-header">
                    <div className="box-logos">
                       <Link to={{pathname: "/"}}> <img className="logoSenai" src={logoSenai} alt=""/></Link>
                       <Link to={{pathname: "/"}}><img className="logoProVagas" src={logoProVagas} alt=""/></Link>
                        <img className="logoProVagas" src={logoProVagas} alt=""/>
                    </div>
                    <ul className="menu">
                        <li className="menu-link"><Link to=''>Vagas</Link></li>
                        <li className="menu-link"><Link to=''>Cadastro</Link>Cadastro</li>
                        <li className="menu-link link-login"><Link to=''>Login</Link></li>
                        <li><Link to='' onClick={(event) => {
                event.preventDefault();
                logout();
              }}>Logout</Link></li>
                    </ul>
                </nav>
            </div>
        </div>
        </div>
    );
} 
export default Header;