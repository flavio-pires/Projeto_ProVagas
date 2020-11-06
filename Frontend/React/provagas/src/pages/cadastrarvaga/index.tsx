import React, { useEffect, useState } from 'react';
import Input from '../../components/inputPerfil/inputperfil';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/logoSenai.png';
import './style.css';
import Navleft from '../../components/Navbar/navbar';
import moment from 'moment';
import TextField from '@material-ui/core/TextField/TextField';

function CadastroVAGA() {

  const [nomevaga, setnomevaga] = useState('');
  const [localizacao, setlocalizacao] = useState('');
  const [limite,setlimite] = useState('');
  const [datalimite, setdata] = useState('')
  const [datainitial, setdateinitial] = useState('')
  const [descricao, setdescricao] = useState('');
  const [salario, setsalario] = useState('');
  

const cadvaga =  () => {
    const novavaga = {
      nomeVaga: nomevaga,
      descricaoAtividade: descricao,
      limiteDeInscricao: limite,
      dataInicio: datainitial,
      dataFinal: datalimite,
      ['localização']: localizacao,
      salario: salario
    }
    
      const urlRequest = "http://localhost:5000/api/vagas";

      console.log(novavaga)

      fetch(urlRequest, {
          method: "POST",
          body: JSON.stringify(novavaga),
          headers: {
              'Content-Type': 'application/json;charset=utf-8',
          }
      })

          .then((response) => {
              return response.json()
              
          })
          .then (data => console.log(data))
          .catch(err => console.error(err));
  }

  return (
    <div className='ol'>
      <Navleft />
      <form onSubmit={event => {

        event.preventDefault();
        cadvaga();
      }
       }>
        <div className="cadastro">
          <div className="box-banner-candidato">
            <img className="imagem-candidato" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
          </div>
          <h1>Cadastro de vagas</h1>
          <h4>Dados da vaga</h4>
          <Input type="text" label="Nome Vaga" name="vaga"
           onChange={e => setnomevaga(e.target.value)} 
            />

            <Input type="text" label="Cidade" name="cidade"
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
            {/* <InputSmaller type="text" label="Tipo da vaga" name="vaga" 
            onChange={e => settipovaga(e.target.value)}
             /> */}
              <InputSmaller type="text" label="Limite de inscrição" name="limite" 
            onChange={e => setlimite(e.target.value)}
             />
          </div>

          <div className='input-duplo'>
                {/* <label htmlFor="Trabalho Remoto" className='label-edit'>Aceita trabalho remoto ?</label> <br />
                    <select onChange={e => setremoto(e.target.value)} className="select-box" name="remoto" id="remoto">
                        <option disabled selected>Selecione uma opção</option>
                        <option value="SIM">SIM</option>
                        <option value="NÃO">NÃO</option>
                    </select> */}
          </div>

          <div className='dat-duplo'>

               <TextField
                        id="dtValidade"
                        label="Data Inicial"
                        type="date"
                        defaultValue=''
                        onChange={e => setdateinitial(e.target.value)}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        />

                         <TextField
                        id="dtValidade"
                        label="Data de Validade"
                        type="date"
                        defaultValue=''
                        onChange={e => setdata(e.target.value)}
                        InputLabelProps={{
                            shrink: true,
                        }}
                        />
          </div>

          <Button value="Finalizar cadastro" />
        </div>
      </form>
    </div>
  );
}
export default CadastroVAGA;