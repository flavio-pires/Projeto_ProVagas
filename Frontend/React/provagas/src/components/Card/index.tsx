import React from 'react';
import Button from '../../components/Button';
import './style.css';

interface CardProps{
  descricao: string;
  titulo: string;
  local: string;
  porte: string;
  tipo: string;
  contrato: string;
}

const Card: React.FC<CardProps> = (props) => {
  return(
    <div className="card">
      <div className="centralizar">
        <div className="conteudo">
          <h3>{props.descricao}</h3>
          <p>{props.titulo}</p>
          <p>{props.local}</p>
          <p>{props.porte}</p>
          <p>{props.tipo}</p>
          <p>{props.contrato}</p>
          <Button value="Saiba mais"/>
        </div>
      </div>
    </div>
  );
}

export default Card;