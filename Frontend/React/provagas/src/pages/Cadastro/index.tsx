import React, { useEffect, useState } from 'react';
import Input from '../../components/Input';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/candidatoImagem.png';
import './style.css';
import Header from '../../components/Header';

function Cadastro() {

  // const [namePCD, setNamePCD] = useState('')
  // const [language, setLanguage] = useState('')
  // const [languageLevel, setLanguageLevel] = useState('')
  // const [courseSenai, setCourseSenai] = useState('')
  // const [newHabilidadesState, setNewHabilidadesState] = useState('');

  const [newCourseSenai, setnewCourseSenaiState] = useState([{
    curso: null,
  }]);

  // GET -  Nivel Escolaridade
  const [escolaridadesDatabase, setEscolaridade] = useState<any>([{
    idPropriedade: null,
    nomePropriedade: null,
  }])

  // GET - Genero
  const [generosDatabase, setGenerosDatabase] = useState<any>([{
    idPropriedade: null,
    nomePropriedade: null,
  }]);

  // GET - Cidade
  const [cidadesDatabase, setCidadesDatabase] = useState([{
    idPropriedade: null,
    nomePropriedade: null,
  }])

  // POST - Endereco
  const [newAddress, setNewAddress] = useState({
    rua: null,
    num: null,
    bairro: null,
    complemento: null,
    cep: null,
    idCidade: null,
    idUsuario: null
  });

  // POST -  Usuario
  const [newUserState, setNewUserState] = useState({
    email: null,
    senha: null,
    telefone: null,
    idTipoUsuario: 1,
    idEndereco: null,
  });

  // POST - Candidato
  const [newCandidato, setNewCandidato] = useState({
    nomeCompletoCandidato: null,
    cpf: null,
    dataNascimento: null,
    linkedin: null,
    idEndereco: null,
    idGenero: null,
    idNivelEscolaridade: null
  });
  
  useEffect(() => {
    fetch('https://localhost:5001/api/NiveisEscolaridades')
      .then(data => data.json())
      .then(json => {
        json.map((item: any) => setEscolaridade((itens: any) => {
          return [...itens, {
            nomePropriedade: item.escolaridade,
            idPropriedade: item.idNivelEscolaridade
          }]
        }))
      })
  
    fetch('https://localhost:5001/api/Generos')
    .then(data => data.json())
    .then(json => {
      json.map((item: any) => setGenerosDatabase((itens: any) => {
        return [...itens, {
          nomePropriedade: item.nomeGenero,
          idPropriedade: item.idGenero
        }]
      }))
    })

    fetch("https://localhost:5001/api/Cidades")
      .then(data => data.json())
      .then(json => {
        json.map((item: any) => setCidadesDatabase((itens: any) => {
          return [...itens, {
            nomePropriedade: item.nomeCidade,
            idPropriedade: item.idCidade
          }]
        }))        
      })

  },[]);

  const functionSetNewUserState = (key: any, value: any) => setNewUserState({ ...newUserState, [key]: value })

  // VIACEP STATE
  const [addressViaCep, setAddressViaCep] = useState({
    bairro: '',
    logradouro: '',
  })

  const requestApiViaCep = async (value: any) => {
    value.replace('-', '')
    if (value.length === 8) {
      const request = await fetch(`https://viacep.com.br/ws/${value}/json/`)

      if (request.status === 200) {
        const data = await request.json()
        const { bairro, logradouro } = data
        setAddressViaCep({
          bairro, logradouro
        });
      }
    }
  }

  const functionSetCandidatoState = (key: any, value: any) => setNewCandidato({ ...newCandidato, [key]: value })


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
          <Input type="password" label="Senha" name="senha" placeholder="A senha deve conter no mínimo 8 caracteres" onChange={event => functionSetNewUserState("senha", event.target.value)} />
          <h4>Informações pessoais</h4>
          <Input type="text" label="Nome completo" name="nome" onChange={event => functionSetCandidatoState("nomeCandidato", event.target.value)} />
          <div className="input-duplo">
            <InputSmaller type="text" label="CPF" name="cpf" onChange={event => functionSetCandidatoState("cpf", event.target.value)} />
            <InputSmaller type="text" label="RG" name="rg" onChange={event => functionSetCandidatoState("rg", event.target.value)} />
          </div>
          <div className="input-duplo">
            <InputSmaller type="date" label="Data de nascimento" name="nascimento" onChange={event => functionSetCandidatoState("dataNascimento", event.target.value)} />
            <InputSmaller type="text" label="Telefone" name="telefone" onChange={event => functionSetCandidatoState("telefone", event.target.value)} />
          </div>
          <div className="input-duplo">
            <InputSmaller type="text" label="CEP" name="cep" onChange={event => requestApiViaCep(event.target.value)} />
            <InputSmaller type="text" label="Bairro" name="bairro" value={addressViaCep.bairro} disabled />
          </div>
          <Input
            type="tex" label="Logradouro" name="logradouro" value={addressViaCep.logradouro} disabled />
          <Input type="tex" label="Complemento" name="complemento" />
          <div className="input-duplo">
            <SelectInput
              labelText="Cidade"
              name="cityInput"
              options={cidadesDatabase}
              callbackChangedValue={value => console.log(value)}
            />
          </div>
          <div className="input-duplo">
            <SelectInput
              labelText="Gênero"
              name="genero"
              options={generosDatabase}
              callbackChangedValue={value => console.log(value)}
            />
            <SelectInput
              labelText="Nivel de escolaridade"
              name="escolaridade"
              options={escolaridadesDatabase}
              callbackChangedValue={value => console.log(value)}
            />
          </div>
          <div className="input-duplo">
            {/* <SelectInput
              labelText="Idioma"
              name="idioma"
              options={newLanguage.map((item) => item.nomeIdioma)}
              callbackChangedValue={ value => setLanguage(value)}
            />
            <SelectInput
              labelText="Nivel idioma"
              name="nivelIdioma"
              options={newLevelLanguage.map((item) => item.nomeNivel)}
              callbackChangedValue={ value => setLanguageLevel(value)}
            />           */}

          </div>
          <Input type="tex" label="LinkedIn" name="linkedin" placeholder="Adicione aqui o link do seu LindekIn" onChange={event => functionSetCandidatoState("linkedin", event.target.value)} />
        </div>
          {/* <div className="box-input-file">
            <label htmlFor="file">Selecione uma foto de perfil:</label>
            <input type="file" name="file" id="file" className="inputfile" />
            <label htmlFor="file">Selecione um arquivo</label>
          </div> */}
          {/* <div className="input-duplo">
            <div className="box-radio-label">

              <label>Possui alguma deficiência?</label>

              <div className="group-radio-label">
                <div className="group-radio">
                  <input id="sem" type="radio" name="radio1" value={1} onChange={()=> {setRadioDeficiencia(1)}} checked={radioDeficiencia === 1 } />
                  <label htmlFor="sem">Sim</label>
                </div>
                                                                                              
                <div className="group-radio">
                  <input id="com" type="radio" name="radio1" value={0} onChange={()=> {setRadioDeficiencia(0)}} checked={radioDeficiencia === 0 }/>
                  <label htmlFor="com">Não</label>
                </div>
              </div>

            </div>
            <SelectInput
              labelText="Se sim, qual?"
              name="pcd"
              options={newPcd.map((item) =>  item.nomeDeficiencia )}
              callbackChangedValue={ value => setNamePCD(value) }
            /> */}
        {/* <div className="input-duplo">
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
        </div> */}
            {/* <SelectInput
              labelText="Curso"
              name="genero"
              options={newCourseSenai.map((item) => item.curso )}
              callbackChangedValue={ value => setCourseSenai(value) }
            /> */}
          {/* <Input type="text" label="Informe suas habilidades"
            name="habilidades"
            placeholder="Ex: Conhecimento em HTML, CSS, Java"
            onChange={event => setNewHabilidadesState(event.target.value)}
          /> */}

          {/* <h4>Experiências profissionais</h4>
          <div className="box-experiencias">
            <div className="input-duplo">
              <InputSmaller type="text" label="Nome da Empresa" name="empresa" onChange={event => functionSetNewExperienceState("nomeEmpresa", event.target.value)} />
              <InputSmaller type="text" label="Cargo" name="cargo" onChange={event => functionSetNewExperienceState("cargo", event.target.value)} />
            </div>
            <div className="input-duplo">
              <InputSmaller type="date" label="Data de início" name="dataInicio" onChange={event => functionSetNewExperienceState("dataInicio", event.target.value)}/>
              <InputSmaller type="date" label="Data término" name="dataTermino" onChange={event => functionSetNewExperienceState("dataTermino", event.target.value)}/>
            </div>
            <div className="box-experiencias-text">
              <label htmlFor="atividades">Descreva suas atividades</label>
              <textarea className="text-experiencias-atividades" name="atividades" onChange={event => functionSetNewExperienceState("", event.target.value)}/>
            </div>
            <input type="submit" className="btn-add-experiencia" value="Adicionar experiência" />

          </div> */}

          <Button value="Finalizar cadastro" />

        {/* </div> */}
      </form>
    </div>
  );
}

export default Cadastro;

