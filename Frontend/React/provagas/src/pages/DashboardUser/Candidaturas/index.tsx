import React, { useEffect, useState } from 'react';
import Navleft from '../../../components/Navbar/navbar'
import './style.css'
import Grafico from '../../../components/grafico'
import IconButton from '@material-ui/core/IconButton/IconButton';
import { parseJWT } from '../../../services/auth';

export default function Candidaturas () {

  const [salario, setsalario] = useState('');
  const [idInscricao, setidinscricao] = useState(0);
  const [localidade, setlcoalidade] = useState('');
  const [ titulo, settitulo] = useState('');
  const [remoto, setremoto] = useState('');
  const [status, setstatus] = useState(''); 
  const [inscricao , setinscricao] = useState([])



useEffect (() => {
  listarInscricao();
}, [])

const listarInscricao = () => {
  fetch(`http://localhost:5000/api/Candidatos/Inscricao/${parseJWT().Id}`, {
      method: 'GET',
      headers: {
          authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
      }
  })
  .then(response => response.json())
  .then(dados => {
    setinscricao(dados);
  })
  .catch(erro => console.error(erro))
}

  return (
    <>
    <aside>
    <Navleft/> 
    </aside>
    <div className='candidaturacenter'>
      <h1 className="candidaturash1">Candidaturas</h1>
      <br/>
      <br/>
     
      <table>
        <tbody>
          {
            inscricao.map((item:any) =>{
              return (      
               <div className="espacamento">
                     <div className='box-shadows'>
                          <div className='rowa'>
                              <tr key={item.idInscricao}>
                                <div className="coluna">
                                  <td><h4>{item.nomeVaga} </h4></td>
                                  <td>Salario: R$ {item.salario}</td>
                                  <td>Localidade: {item.localizacao}</td>
                                  <td>Trabalho Remoto ?{item.aceitaTrabalhoRemoto}</td>

                                </div>
                              </tr>

                            </div>
                       </div>
                 </div>
              )
            })
          }
        </tbody>       
      </table>
     
      </div>

    </>
  )
}