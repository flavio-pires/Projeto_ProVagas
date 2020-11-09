import React from 'react';
import Button from '../../components/Button';
import './style.css';
import '../../assets/global.css';
import Header from '../../components/Header';
import imgdetalhevaga from '../../assets/images/imgdetalhevaga.png';
import iconelocal from '../../assets/images/local.png';
import iconeporte from '../../assets/images/porte.png';
import iconecontrato from '../../assets/images/tipo-contrato.png';
import logo_brq from '../../assets/images/logo_brq.png';
import Footer from '../../components/Footer';
import * as GrIcons from 'react-icons/gr'

function DetalheVaga() {
  return (
      <div>
        <Header/>
        <body>
          <div className="detalhe">
            <img src={imgdetalhevaga} alt="Detalhes da vaga"/>
            <div className="infovaga">
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
              </ul>
              <Button value="Quero me candidatar" id="btnvaga1"/>
            </div>
            <div className="detalhesvaga">
              <h1>Descrição da empresa</h1>
                <p>Paixão por transformar negócios com tecnologia, esse é o propósito que move a BRQ há 27 anos. Com soluções digitais próprias e customizadas, a BRQ acelera a transformação digital das maiores empresas que operam no Brasil. 

                  Construímos aplicações sob medida assim como produtos e canais digitais. Implementamos também uma gama abrangente de soluções de tecnologia e fazemos a gestão de aplicações, de infraestrutura e de processos suportando nossos clientes em todo o ciclo da transformação digital:
                  •	 Pensar e Desenhar
                  •	 Aportar e Definir Tecnologia
                  •	 Construir e Evoluir

                  Também possuímos soluções proprietárias e de terceiros para acelerar ainda mais a introdução e evolução das tecnologias exponenciais nos negócios. 

                  Para a BRQ, o consumidor está sempre em foco.  Por meio do Lean Digital a Transformação Digital acontece de forma ágil e contínua eliminando desperdícios, acelerando a comunicação e otimizando a produtividade através de mudanças culturais e de processos.
                </p>
              <h1>Atividades e responsabilidades</h1>
                <p>Em todas as diferentes fases do projeto, desde a definição de requisitos técnicos, operacionais e do usuário até o planejamento, controle de qualidade e testes. Será responsável, também, por criar uma arquitetura conceitual e desenvolver opções de solução que correspondam às necessidades dos seus clientes, fazer parcerias com equipes de tecnologia multifuncional para integrar soluções e coordenar com equipes offshore e globais.
                  Nessa posição é importante que tenha disponibilidade para viajar, conforme necessário. Ou seja, se você possui experiencia como líder, inspirando pessoas, treinando e acompanhando equipes, se prepare porque será uma de suas atividades.
                </p>
              <h1>Benefícios oferecidos</h1>
                <ul>
                  <li>Vale refeição ou alimentação; </li>
                  <li>Vale transporte ou fretado; </li>
                  <li>Assistência médica e odontológica; </li>
                  <li>Certificações e treinamentos;  </li>
                  <li>Seguro de Vida; </li>
                  <li>Previdência Privada; </li>
                  <li>EF – Inglês; </li>
                  <li>Horários flexíveis;  </li>
                  <li>Participação nos resultados da empresa; </li>
                  <li>Gympass; </li>
                  <li>Auxílio creche; </li>
                  <li>Career Advisor (um braço direito para orientar a sua carreira); </li>
                  <li>Exposição com times globais a depender do projeto; </li>
                  <li>Avaliação formal de performance e carreira; </li>
                  <li>Job Rotation (possibilidade de rotacionar entre projetos, conhecer mais tecnologias e diversos segmentos de mercado); </li>
                </ul>
              </div>
          </div>
        </body>
        <Footer/>
      </div>
  );
}

export default DetalheVaga;