import React from 'react';
import Input from '../../components/Input';
import Button from '../../components/Button';
import Header from '../../components/Header';
import {Link} from 'react-router-dom';
import './style.css';
import imgvaga from '../../assets/images/imgvaga.png';
import imglupa from '../../assets/images/lupa.png';
import iconelocal from '../../assets/images/local.png';
import iconeporte from '../../assets/images/porte.png';
import iconecontrato from '../../assets/images/tipo-contrato.png';
import logo_brq from '../../assets/images/logo_brq.png';
import imgfiltro from '../../assets/images/filtro.png';
import Footer from '../../components/Footer';

function Vagas() {
  return (
      <div>
        <Header/>
          <div className="telavagas">
            <img src={imgvaga} alt="Imagem da página de vagas"/>
              <div className="buscarvaga">
                <img src={imglupa} alt="Lupa"/>
                <Input type="text" name="buscar" label="" placeholder="Buscar"/>
              </div>
            <div className="vagas2">
              <div className="filtros">
                <ul className="filtrar">
                  <img src={imgfiltro} alt="Imagem de filtro"/>
                  <h2>Filtrar</h2>
                </ul>
              </div>
              <ul className="vaga1">
                <h3>Estágio em Desenvolvimento de Sistemas</h3>
                <hr/>
                <div className="topicovaga">
                  <div className="imgtopico">
                    <img src={logo_brq} alt="Logo da empresa"/>
                  </div>
                  <div className="topicos">
                    <li><img src={iconelocal} alt="Ícone de local"/>São Paulo</li>
                    <li><img src={iconeporte} alt="Ícone de porte da empresa"/>Grande</li>
                    <li><img src={iconecontrato} alt="Ícone de contrato"/>Estagiário</li>
                  </div>
                </div>
                <Link to="/detalhevaga" className="mudabotao"><Button value="Saiba mais" id="btnvaga1"/></Link>
              </ul>
          </div>
        </div>
        <Footer/>
      </div>
  );
}

export default Vagas;