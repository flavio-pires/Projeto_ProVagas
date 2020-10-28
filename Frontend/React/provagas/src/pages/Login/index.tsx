import React from 'react';
import Input from '../../components/Input';
import Button from '../../components/Button';
import imglogin from '../../assets/images/img_login.png'
import './style.css';
import Header from '../../components/Header';

function Login() {
  return (
      <div>
        <Header/>
        <div className="login">
          <img src={imglogin} alt="Imagem principal da tela de login"/>
            <div className="login-dados">
                <h1>Bem vindo!</h1>
                <Input type="text" label="Nome" name="nome"/>
                <Input type="email" label="E-mail" name="email"/>
                <Input type="password" label="Senha" name="senha"/>
                <Button value="Entrar"/>
            </div>
        </div>
      </div>
  );
}

export default Login;