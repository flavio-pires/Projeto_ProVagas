import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';
import Button from '../../components/Button';
import imglogin from '../../assets/images/img_login.png'
import './style.css';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import InputSmaller from '../../components/InputSmaller';

function Login() {

  let history = useHistory();

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const login = () => {
    const login ={
      email: email,
      senha: senha
    }
  

    fetch('http://localhost:5000/api/login', {
      method: 'POST',
      body: JSON.stringify(login),
      headers: {
        'content-type': 'application/json'
      },
    })

    .then (response => response.json())
    .then (dados => {
      if (dados.token !== undefined) {
        localStorage.setItem('provagas-chave-autenticacao', dados.token)
        history.push('/dashboarempresa/vaga')
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
                  <InputSmaller type="email" label="" name="email" placeholder="Digite seu e-mail" onChange={e => setEmail(e.target.value)}/>
                  <InputSmaller type="password" label="" name="senha" placeholder="Digite sua senha" onChange={e => setSenha(e.target.value)}/>
                  <Button value="Entrar"/>
                </form>
            </div>
        </div>
        <Footer/>
      </div>
  );
}

export default Login;