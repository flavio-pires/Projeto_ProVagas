import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';
import Input from '../../components/Input';
import Button from '../../components/Button';
import imglogin from '../../assets/images/img_login.png'
import './style.css';
import Header from '../../components/Header';

function Login() {

  let history = useHistory();

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const login = () => {
    const login ={
      email: email,
      senha: senha
    }
  

    fetch('http://localhost:5000/api/conta/login', {
      method: 'POST',
      body: JSON.stringify(login),
      headers: {
        'content-type': 'application/json'
      },
    })

    .then (response => response.json())
    .then (dados => {
      if (dados.token !== undefined) {
        localStorage.setItem('token-provagas', dados.token)
        history.push('/')
      }
      else{
        alert('Senha ou e-mail inválido');
      }
    })
    .catch(erro => console.error(erro))
  }

  return (
      <div>
        <Header/>
        <div className="login">
          <img src={imglogin} alt="Imagem principal da tela de login"/>
            <hr/>
            <div className="login-dados">
                <h1>Bem vindo!</h1>
                <form onSubmit={ event => {
                  event.preventDefault();
                  login();
                }}>
                  <Input type="email" label="" name="email" placeholder="Digite seu e-mail" onChange={e => setEmail(e.target.value)}/>
                  <Input type="password" label="" name="senha" placeholder="Digite sua senha" onChange={e => setSenha(e.target.value)}/>
                  <Button value="Entrar"/>
                </form>
            </div>
        </div>
      </div>
  );
}

export default Login;