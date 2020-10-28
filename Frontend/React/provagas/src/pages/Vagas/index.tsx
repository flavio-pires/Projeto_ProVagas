import React from 'react';
import Input from '../../components/Input';
import Button from '../../components/Button';
import './style.css';
import imgvaga from '../../assets/images/imgvaga.png';

function Vagas() {
  return (
      <div className="centro">
        <div className="vaga">
          <h1>Vagas</h1>
          <img src={imgvaga} alt="Imagem da página de vagas"/>
        </div>
      </div>
  );
}

export default Vagas;