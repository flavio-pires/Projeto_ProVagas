import React, { useState } from 'react';
import Input from '../../components/Input';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/candidatoImagem.png';
import './style.css';
import Header from '../../components/Header';

function Cadastro() {

  const [newUserState, setNewUserState] = useState({
    email: null,
    senha: null,
    idTipoUsuario: 1,
    idEndereco: null,
  });

  const [newAddress, setNewAddress] = useState({

    rua: null,
    num: null,
    bairro: null,
    complemento: null,
    cep: null,
    idCidade: null,
  });

  const [newCity, setNewCity] = useState({

    nomeCidade: null,
    idEstado: null,

  })

  const [newCountry, setNewCountry] = useState('')

  const [newEscolarida, setEscolaridade] = useState('')

  const [newNivelIngles, setNivelIngles] = useState('')

  const [newGenero, setGenero] = useState('')



  const functionSetNewUserState = (key: any, value: any) => setNewUserState({ ...newUserState, [key]: value })

  const [addressViaCep, setAddressViaCep] = useState({
    bairro: '',
    logradouro: '',
    localidade: '',
    uf: '',
  })

  const requestApiViaCep = async (value: any) => {

    value.replace('-', '')

    if (value.length === 8) {
      const request = await fetch(`https://viacep.com.br/ws/${value}/json/`)

      if (request.status === 200) {
        const data = await request.json()
        const { bairro, logradouro, localidade, uf} = data
        setAddressViaCep({
          bairro, logradouro, localidade, uf
        });

      }
    }
  }

  const [newCandidato, setNewCandidato] = useState({
    NomeCompletoCandidato: null,
    CPF: null,
    DataNascimento: null,
    Linkedin: null,
    FotoPerfil: null,
    PossuiDeficiencia: null,
    Deficiencia: null,
    CursandoSENAI: null,
    Curso: null,
    NomeEmpresaExperienciaProfissional: null,
    Cargo: null,
    DataInicio: null,
    DataFim: null,
    EmpregoAtual: null,
    DescriçãoAtividades: null,
    IdUsuario: null,
    IdGenero: null,
    IdNivelIngles: null,
    IdNivelEscolaridade: null,

  });

  const [newHabilidadesState, setNewHabilidadesState] = useState('');


  return (
    <div className='ol'>
      <Header />
      <form>
        <div className="cadastro">
          <div className="box-banner-candidato">
            <img className="imagem-candidato" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
          </div>
          <h1>Cadastro de candidato</h1>
          <h4>Dados de acesso</h4>
          <Input type="email" label="E-mail" name="email" onChange={event => functionSetNewUserState("email", event.target.value)} />
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
            <InputSmaller type="text" label="CEP" name="cep"
              onChange={event => {

                const { value } = event.target
                requestApiViaCep(value)
              }}
            />
            <InputSmaller type="text" label="Bairro" name="bairro"  value={addressViaCep.bairro} disabled/>
          </div>
          <Input type="tex" label="Logradouro" name="logradouro" value={addressViaCep.logradouro} disabled/>
          <div className="input-duplo">
            <InputSmaller type="text" label="Cidade" name="cidade" value={addressViaCep.localidade} disabled />
            <InputSmaller type="text" label="Estado" name="estado" value={addressViaCep.uf} disabled />
          </div>
          <div className="input-duplo">
            <SelectInput
                labelText="Gênero"
                name="genero"
                options={["Feminino", "Masculino", "Outro"]}
                callbackChangedValue={value => setGenero(value)}
            />
            <InputSmaller type="text" label="Nível de inglês" name="ingles" />
          </div>
          <Input type="tex" label="LinkedIn" name="linkedin" placeholder="Adicione aqui o link do seu LindekIn" />
          <div className="box-input-file">
            <label htmlFor="file">Selecione uma foto de perfil:</label>
            <input type="file" name="file" id="file" className="inputfile" />
            <label htmlFor="file">Selecione um arquivo</label>
          </div>



          <div className="input-duplo">
            <div className="box-radio-label">

              <label>Possui alguma deficiência?</label>

              <div className="group-radio-label">
                <div className="group-radio">
                  <input id="sem" type="radio" name="radio1" value="sem" />
                  <label htmlFor="sem">Sim</label>
                </div>

                <div className="group-radio">
                  <input id="com" type="radio" name="radio1" />
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
                  <input id="sim" type="radio" name="radio" value="sem" />
                  <label htmlFor="sim">Sim</label>
                </div>

                <div className="group-radio">
                  <input id="nao" type="radio" name="radio" />
                  <label htmlFor="nao">Não</label>
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
            <input type="submit" className="btn-add-experiencia" value="Adicionar experiência" />

          </div>

          <Button value="Finalizar cadastro" />

        </div>
      </form>
    </div>
  );
}

export default Cadastro;