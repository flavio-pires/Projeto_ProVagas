import React, { useEffect, useState } from 'react';
import Input from '../../components/inputPerfil/inputperfil';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/logoSenai.png';
import './style.css';
import Navleft from '../../components/Navbar/navbar';
import moment from 'moment';

function Cadastro() {

  const [nomevaga, setnomevaga] = useState('');
  const [localizacao, setlocalizacao] = useState('');
  const [limite,setlimite] =useState('');
  const [datavalidade, setdata] = useState('')
  const [datainitial, setdateinitial] = useState('')
  const [descricao, setdescricao] = useState('');
  const [remoto, setremoto] = useState('');
  const [salario, setsalario] = useState('');
  const [beneficios,setbeneficios] = useState([]);
  const [nivelvaga, setnivelvaga] = useState('');
  const [tipovaga, settipovaga] = useState('');
  
//   useEffect( () => {
//     listar();
//   }, []);

//   const listar = () => {
//     fetch('http://localhost:5001/api/beneficios', {
//         method: 'GET',
//     })
//         .then(response => response.json())
//         .then(dados => {
//             // setBeneficios(dados);
//             setbeneficios(dados);

//         })
//         .catch(erro => console.error(erro))
// }

const vaga = async () => {
    const novavaga = {
      NomeVaga:nomevaga,
      DescricaoAtividade:descricao,
      LimiteDeInscricao: limite,
      DataInicio: datainitial,
      DataFinal: datavalidade,
      AceitaTrabalhoRemoto: remoto,
      Localizacao:localizacao,
      Salario:salario,
      IdNivelVagaNavigation: {
        NomeNivelVaga: nivelvaga
      },
      IdTipoVagaNavigation: {
        NomeTipoVaga: tipovaga
      }
    }

    try {
    const URL =  "http://localhost:5000/api/vagas"
     const request = fetch(URL, {
        method: "post",
        headers: {
            'Content-Type': 'application/json',
            authorization: 'Bearer ' + localStorage.getItem('token')
        },
        body: JSON.stringify(novavaga)
    })
    const response = await (await request).json()

    if (response === 'Erro ao cadastrar vaga') {
        alert(response);
    }
    else {
        alert(response);
        window.location.reload();
    }

  } catch (error) {
    throw new Error(error)
}
}

  return (
    <div className='ol'>
      <Navleft />
      <form onSubmit={event => {

        event.preventDefault();
        vaga();
      }
       }>
        <div className="cadastro">
          <div className="box-banner-candidato">
            <img className="imagem-candidato" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
          </div>
          <h1>Cadastro de vagas</h1>
          <h4>Dados da vaga</h4>
          {/* <Input type="text" label="Nome Vaga" name="vaga"
           onChange={e => setnomevaga(e.target.value)} 
            /> */}
          
        <label htmlFor=''>Nome Vaga</label>
        <br/>
        <input type="text" id='nomevaga' onChange={e => setnomevaga(e.target.value)}/>

          <Input type="text" label="Cidade" name="localizacao" placeholder="Ex: Sâo Paulo" 
          onChange={e => setlocalizacao(e.target.value)} 
          />

          <div className="box-experiencias">           
            <div className="box-experiencias-text">
              <label htmlFor="atividades">Descreva as atividades dessa vaga</label>
              <br/>
              <textarea className="text-experiencias-atividades" name="atividades" onChange={e => setdescricao(e.target.value)}/>
            </div>
          </div>
          
          <div className="input-duplo">
            <InputSmaller type="text" label="Salário" name="salario" 
            onChange={e => setsalario(e.target.value)} 
            />
            <InputSmaller type="text" label="Tipo da vaga" name="vaga" 
            onChange={e => settipovaga(e.target.value)}
             />
          </div>

          <div className='input-duplo'>
              <InputSmaller type="text" label="Limite de inscrição" name="limite" 
            onChange={e => setlimite(e.target.value)}
             />
                <label htmlFor="Trabalho Remoto" className='label-edit'>Aceita trabalho remoto ?</label> <br />
                    <select onChange={e => setremoto(e.target.value)} className="select-box" name="remoto" id="remoto">
                        <option disabled selected>Selecione uma opção</option>
                        <option value="SIM">SIM</option>
                        <option value="NÃO">NÃO</option>
                    </select>
          </div>

          <div className='input-duplo'>
            <InputSmaller type="text" label="Data inial" name="limite" 
            onChange={e => setdateinitial(e.target.value)}
             />
              <InputSmaller type="text" label="Data Limite" name="limite" 
            onChange={e => setdata(e.target.value)}
             />
          </div>

          <Button value="Finalizar cadastro" />
        </div>
      </form>
    </div>
  );
}
export default Cadastro;