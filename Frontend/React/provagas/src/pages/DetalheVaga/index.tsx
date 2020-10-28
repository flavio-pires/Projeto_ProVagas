import React from 'react';
import Input from '../../components/Input';
import Button from '../../components/Button';
import './style.css';

function DetalheVaga() {
  return (
      <div className="centro">
        <div className="detalhe">
          <h1>Detalhe da Vaga</h1>
          <Input type="text" label="Nome" name="nome"/>
          <Input type="email" label="E-mail" name="email"/>
          <Input type="password" label="Senha" name="senha"/>
          <Button value="Finalizar cadastro"/>
        </div>
      </div>
  );
}

export default DetalheVaga;