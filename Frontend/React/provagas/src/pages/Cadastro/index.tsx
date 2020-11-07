import React, { useEffect, useState } from 'react';
import Input from '../../components/Input';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/candidatoImagem.png';
import './style.css';
import Header from '../../components/Header';

function Cadastro() {

  const [namePCD, setNamePCD] = useState('')
  const [nameGenero, setNameGenero] = useState('')
  const [educationLevel, setEducationLevel] = useState('')
  const [language, setLanguage] = useState('')
  const [languageLevel, setLanguageLevel] = useState('')
  const [courseSenai, setCourseSenai] = useState('')


  const [newEscolaridade, setEscolaridade] = useState<any>([{
    idPropriedade: null,
    nomePropriedade: null,
  }])

  
  useEffect(() => {

    fetch('https://localhost:5001/api/PCDs')
    .then(data => data.json())
    .then(json => setNewPcd(json))
    console.log('retorno do banco, pcd ', newPcd);

    fetch('https://localhost:5001/api/NiveisEscolaridades')
    .then(data => data.json())
    .then(json =>{
      console.log(json)
      json.map(( e : any)  => setEscolaridade([...newEscolaridade, {idPropriedade: e.idEscolaridade, nomePropriedade: e.escolaridade}])) 
      
    })
    console.log('retorno da escolaridade ', newEscolaridade);
  
    fetch('https://localhost:5001/api/Generos')
    .then(data => data.json())
    .then(json => setnewGenderState(json))
    console.log('retorno do gênero ', newGender);

    fetch('https://localhost:5001/api/CursosSenai')
    .then(data => data.json())
    .then(json => setnewCourseSenaiState(json))
    console.log('retorno do curso senai ', newCourseSenai);

    fetch('https://localhost:5001/api/Idiomas')
    .then(data => data.json())
    .then(json => setNewLanguageState(json))
    console.log('retorno do idioma ', newLanguage);

    fetch('https://localhost:5001/api/NiveisIdiomas')
    .then(data => data.json())
    .then(json => setNewLevelLanguageState(json))
    console.log('retorno do nivel idioma ', newLevelLanguage);

  },[]);


  const [newCourseSenai, setnewCourseSenaiState] = useState([{
    curso: null,
  }]);

  const [newLanguage, setNewLanguageState] = useState([{
    idIdioma:null,
    nomeIdioma: null,
  }]);

   const [newLevelLanguage, setNewLevelLanguageState] = useState([{
    nomeNivel: null,
  }])

  const [newPcd, setNewPcd] = useState([{
    idDeficiencia: null,
    nomeDeficiencia: null
  }]);

  const [radioDeficiencia, setRadioDeficiencia] = useState(2);

  const [newPcdCandidate, setNewPcdCandidate] = useState([{
	  possuiDeficiencia: radioDeficiencia,
	  idCandidato: null,
	  idPCD: null,
  }]);

  useEffect(() => {
    console.log('radio pcd',radioDeficiencia)
  },[radioDeficiencia]);

 
  
  const [newGender, setnewGenderState] = useState([{
    nomeGenero: null,
  }]);

  const [newCountry, setNewCountry] = useState('')

  const [newLocality, setnewLocalityState] = useState({
    nomeEstado: null,
  }) 

  const [newCity, setNewCity] = useState({
    nomeCidade: null,
    idEstado: null,
  })
  
  const [newAddress, setNewAddress] = useState({
    
    rua: null,
    num: null,
    bairro: null,
    complemento: null,
    cep: null,
    idCidade: null,
  });
  
  const [newUserState, setNewUserState] = useState({
    email: null,
    senha: null,
    telefone: null,
    idTipoUsuario: 1,
    idEndereco: null,
  });

  const [newExperience, setNewExperienceState] = useState({
	nomeExperiencia: null,
	nomeEmpresa: null,
	cargo: null,
	dataInicio: null,
	dataFim: null,
	empregoAtual: null,
	descricaoAtividade: null,
	IdCandidato: null,
  });

  const functionSetNewExperienceState = (key: any, value: any) => setNewExperienceState({ ...newExperience, [key]: value })


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
        const { bairro, logradouro, localidade, uf } = data
        setAddressViaCep({
          bairro, logradouro, localidade, uf
        });

      }
    }
  }

  const [newCandidato, setNewCandidato] = useState({

  });

  const functionSetCandidatoState = (key: any, value: any) => setNewCandidato({ ...newCandidato, [key]: value })


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
            <InputSmaller type="text" label="CEP" name="cep"
              onChange={event => {

                const { value } = event.target
                requestApiViaCep(value)
              }}
            />
            <InputSmaller type="text" label="Bairro" name="bairro" value={addressViaCep.bairro} disabled />
          </div>
          <Input
            type="tex" label="Logradouro" name="logradouro" value={addressViaCep.logradouro} disabled />
          <Input type="tex" label="Complemento" name="complemento"/>
          <div className="input-duplo">
            <InputSmaller type="text" label="Cidade" name="cidade" value={addressViaCep.localidade} disabled />
            <InputSmaller type="text" label="Estado" name="estado" value={addressViaCep.uf} disabled />
          </div>
          <div className="input-duplo">
            {/* <SelectInput
              labelText="Gênero"
              name="genero"
              options={newGender.map((item) => item.nomeGenero)}
              callbackChangedValue={ value => setNameGenero(value) }
            /> */}
            <SelectInput
              labelText="Nivel de escolaridade"
              name="escolaridade"
              options={newEscolaridade}
              callbackChangedValue={ value => console.log(value)}
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
                  <input id="sem" type="radio" name="radio1" value={1} onChange={()=> {setRadioDeficiencia(1)}} checked={radioDeficiencia === 1 } />
                  <label htmlFor="sem">Sim</label>
                </div>
                                                                                              
                <div className="group-radio">
                  <input id="com" type="radio" name="radio1" value={0} onChange={()=> {setRadioDeficiencia(0)}} checked={radioDeficiencia === 0 }/>
                  <label htmlFor="com">Não</label>
                </div>
              </div>

            </div>
            {/* <SelectInput
              labelText="Se sim, qual?"
              name="pcd"
              options={newPcd.map((item) =>  item.nomeDeficiencia )}
              callbackChangedValue={ value => setNamePCD(value) }
            /> */}
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
            {/* <SelectInput
              labelText="Curso"
              name="genero"
              options={newCourseSenai.map((item) => item.curso )}
              callbackChangedValue={ value => setCourseSenai(value) }
            /> */}
          </div>
          <Input type="text" label="Informe suas habilidades"
            name="habilidades"
            placeholder="Ex: Conhecimento em HTML, CSS, JavaScript"
            onChange={event => setNewHabilidadesState(event.target.value)}
          />

          <h4>Experiências profissionais</h4>
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

          </div>

          <Button value="Finalizar cadastro" />

        </div>
      </form>
    </div>
  );
}

export default Cadastro;

