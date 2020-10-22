import React from 'react';
import logosenai from './../../assets/Image/logo-senai.png';
import facebook from './../../assets/Image/face-icon.png';
import instagram from './../../assets/Image/insta-icon.png';
import twitter from './../../assets/Image/twit-icon.png';
import linkedin from './../../assets/Image/link-icon.png';
import './style.css';




function Footer() {
  return (
    <div className="footer">
      <img src={logosenai} alt="Logotipo do Senai, vermelho e branco." />
      <div>
        <p>Escola SENAI de informatica</p>
        <p>Avenida Alameda Barâo de Limeira</p>
        <p>CEP: 01202-001</p>
        <p>Telefone: (11)3273-5000</p>
      </div>
      <img src={facebook} alt="Logotipo facebook, com link direto para o facebook." />
      <img src={instagram} alt="Logotipo instagram, com link direto para o instagram." />
      <img src={twitter} alt="Logotipo twitter, com link direto para o twitter." />
      <img src={linkedin} alt="Logotipo linkedin, com link direto para o linkedin." />
    </div>
  );
}

export default Footer;
