import React from 'react';
import Navleft from '../../components/Navbar/navbar';
import './style.css'
import imghiring from '../../assets/images/undraw_hiring_cyhs.png';
import Button from '../../components/Button/index';
import './style.css'



export default function dashboard() {
    return (
        <div>
              <aside>
              <Navleft/>  

              </aside>
                <div className='row'>              
               <div className='box-shadow'>
                   <p>0</p>   
                   <hr/>
                   <h3>Vagas</h3>
                </div>
               <div className='divhf4'>
                <img src={imghiring} alt="imagem ilustrativa"/>
               </div>
               </div>
               <br/>
               <div className='gc'>

               <div className='conteudo1'>
                   <br/>
                <h4>O que está esperando ?</h4><br/>
                <p>Abra já a sua vaga e encontro o estagiário perfeito para sua empresa.</p><br/>
                <Button value='Cadastre já uma vaga !'/>
               </div>
               <div className='conteudo1'>
                   <br/>
                <h4>Sabe quem somos?</h4><br/>
                <p>Clique aqui e saiba mais de como é a nossa politica de aprendizado</p><br/>
                <Button value='Clique aqui'/>
               </div>
               </div>
        </div>
    )
}
  