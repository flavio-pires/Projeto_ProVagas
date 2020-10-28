import React from 'react';
import Header from '../../components/Header/index';
import Button from '../../components/Button';
import Card from '../../components/Card';
import imgprincipal from '../../assets/images/imgprincipal_home.png';
import imgcandidato from '../../assets/images/imgcandidato_home.png';
import imgempresa from '../../assets/images/imgempresa_home.png';
import './style.css';

function Home(){
    return(
            <div>
                <Header/>
                <div className="home">
                    <div className="slogan">
                        <div className="texto-slogan">
                            <h1>Pensado para empresas, pensado para candidatos!</h1>
                                <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been
                                    the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley
                                    of type and scrambled it to make a type specimen book.
                                </p>
                            <div className="botao-slogan">
                                <div className="btn1home">
                                <Button value="Encontrar uma vaga"/>
                                </div>
                                <div className="btn2home">
                                <Button value="Publicar uma vaga"/>
                                </div>
                            </div>
                        </div>
                        <img id="imgprincipal" src={imgprincipal} alt="Imagem principal ProVagas"/>
                    </div>
                    <div className="candidato">
                        <img src={imgcandidato} alt="Imagem candidato"/>
                        <h2>Candidato</h2>
                        <p>Candidatura simplificada</p>
                        <p>Plataforma segura</p>
                        <p>Vagas direcionadas ao seu perfil</p>
                    </div>
                    <div className="empresa">
                        <img src={imgempresa} alt="Imagem candidato"/>
                        <h2>Empresa</h2>
                        <p>Candidatos qualificados</p>
                        <p>Plataforma gratuita</p>
                        <p>Acompanhamento do processo</p>
                    </div>
                    <div className="ultimasvagas">
                        <h2>Nossas últimas vagas</h2>
                        <Card descricao="Vaga" titulo="empresa" local="São Paulo" porte="Grande" tipo="Junior" contrato="CLT"/>
                        <Card descricao="Vaga" titulo="empresa" local="São Paulo" porte="Grande" tipo="Junior" contrato="CLT"/>
                        <Card descricao="Vaga" titulo="empresa" local="São Paulo" porte="Grande" tipo="Junior" contrato="CLT"/>
                        <Button value="Ver mais"/>
                    </div>
                </div>       
            </div>
    );
}

export default Home;