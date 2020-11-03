import React from 'react';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/candidatoImagem.png';
import './style.css';
import Header from '../../components/Header';

function Cadastro() {
  return (
    <div className=''>
      <Header />
      <div className="cadastro">
        <div className="box-banner-candidato">
          <img className="imagem-candidato" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
        </div>
        <h1>Cadastro de candidato</h1>
        <h4>Dados de acesso</h4>
        <Input type="email" label="E-mail" name="email" />
        <Input type="password" label="Senha" name="senha" placeholder="A senha deve conter no mínimo 8 caracteres" />
        <h4>Informações pessoais</h4>
        <Input type="text" label="Nome completo" name="nome" />
        <div className="input-duplo">
          <InputSmaller type="text" label="CPF" name="cpf" />
          <InputSmaller type="text" label="RG" name="rg" />
        </div>
        <div className="input-duplo">
          <InputSmaller type="date" label="Data de nascimento" name="nascimento" />
          <InputSmaller type="text" label="Telefone" name="telefone " />
        </div>
        <div className="input-duplo">
          <InputSmaller type="text" label="CEP" name="cep" />
          <InputSmaller type="text" label="Bairro" name="bairro" />
        </div>
        <Input type="tex" label="Logradouro" name="logradouro" />
        <div className="input-duplo">
          <InputSmaller type="text" label="Cidade" name="cidade" />
          <InputSmaller type="text" label="Estado" name="estado" />
        </div>
        <div className="input-duplo">
          <InputSmaller type="text" label="Nível de escolaridade" name="escolaridade" />
          <InputSmaller type="text" label="Nível de inglês" name="ingles" />
        </div>
        <div className="box-input-file">
          <InputSmaller className="input-image-user" type="file" label="Foto de perfil" name="foto-candidato" />
        </div>



        <div className="input-duplo">
          <div className="box-radio-label">

            <label>Possui alguma deficiência?</label>

            <div className="group-radio-label">
              <div className="group-radio">
                <input id="sem" type="radio" name="radio" value="sem" />
                <label htmlFor="sem">Sim</label>
              </div>

              <div className="group-radio">
                <input id="com" type="radio" name="radio" />
                <label htmlFor="com">Não</label>
              </div>
            </div>

          </div>
          <InputSmaller type="text" label="Se sim, qual?" name="deficiencia" />
        </div>
        <div className="input-duplo">
          <div className="box-radio-label">

            <label>Atualmente está cursando SENAI?</label>

            <div className="group-radio-label">
              <div className="group-radio">
                <input id="sem" type="radio" name="radio" value="sem" />
                <label htmlFor="sem">Sim</label>
              </div>

              <div className="group-radio">
                <input id="com" type="radio" name="radio" />
                <label htmlFor="com">Não</label>
              </div>
            </div>

          </div>
          <InputSmaller type="text" label="Informe o curso" name="deficiencia" />
        </div>
        <Input type="text" label="Informe suas habilidades" name="habilidades" placeholder="Ex: Conhecimento em HTML, CSS, JavaScript" />
        <h4>Experiências profissionais</h4>
        <div className="box-experiencias">
          <div className="input-duplo">
            <InputSmaller type="text" label="Nome da Empresa" name="empresa" />
            <InputSmaller type="text" label="Cargo" name="cargo" />
          </div>
          <div className="input-duplo">
            <InputSmaller type="date" label="Data de início" name="dataInicio" />
            <InputSmaller type="date" label="Data término" name="dataTermino" />
          </div>
          <div className="box-experiencias-text">
            <label htmlFor="atividades">Descreva suas atividades</label>
            <textarea className="text-experiencias-atividades" name="atividades" />
          </div>
          <input type="submit" className="btn-add-experiencia" value="Adicionar experiência"/>

        </div>

        <Button value="Finalizar cadastro" />

      </div>
    </div>
  );
}

export default Cadastro;