import React from 'react';
import Navleft from '../../components/Navbar/navbar'
import './style.css'
import Grafico from '../../components/grafico'

export default function candidaturas () {
  return (
    <>
    <Navleft/>
      <h1>Candidaturas</h1>
    <br/>
    <br/>
    <div className='center'>
      <div className='box-shadows'>
        <div className='rowa'>
        <Grafico/>
        <div className='columns'> 
        <h4>Desenvolvedor Júnior</h4>
        <br/>
        <p>Salario: 1100</p>
        <p>Localidade: São Paulo</p>
        <p>Trabalho Remoto ? Não</p>

        </div>
          <div className="status">
            <h4>Status da candidatura</h4>
            <p>Em processo de seleção</p>
          </div>
        </div>
        </div>
      </div>

    </>
  )
}