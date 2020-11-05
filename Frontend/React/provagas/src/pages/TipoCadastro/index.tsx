import React from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header/index';
import './style.css';
import ImageCandidato from '../../assets/images/candidatoImagem.png';
import ImageEmpresa from '../../assets/images/empresaImagem.png';
import ImageColaborador from '../../assets/images/colaboradorImagem.png';


function TipoCadastro() {
    return (
        <div className="">
            <Header />
            <div className="tipo-cadastro-container">
            <h1 className="tipo-cadastro-titulo">Selecione sua opção:</h1>
                 <div className="container-cards">
                    <div className="card">
                        <h3 className="card-titulo">Candidato</h3>
                        <img src={ImageCandidato} className="imagem-candidato card-image" alt="desenho de duas pessoas sentados escrevendo"/>
                    </div>
                    <div className="card">
                        <h3 className="card-titulo">Empresa</h3>
                        <img src={ImageEmpresa}  className="imagem-empresa card-image" alt="desenho de dois homens de terno apertando as mãos"/>
                    </div>
                    <div className="card">
                        <h3 className="card-titulo">Colaborador SENAI</h3>
                        <img src={ImageColaborador} className="imagem-colaborador card-image" alt="desenho de duas sentadas mexendo no computador"/>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    );
}

export default TipoCadastro;