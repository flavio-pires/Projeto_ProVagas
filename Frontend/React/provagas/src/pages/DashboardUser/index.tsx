import React from 'react';
import Navleft from '../../components/Navbar/navbar';
import './style.css'
import imgsetup from '../../assets/images/undraw_setup_obqo.png';
import imgdisc from '../../assets/images/unnamed.png'
import Button from '../../components/Button/index';



function dashboard() {
    return (
        <div>
              <Navleft/>  
                <div className='row'>              
               <div className='box-shadow'>
                   <p>0</p>   
                   <hr/>
                   <h3>Candidaturas</h3>
                </div>
               <div className='divhf'>
                <img src={imgsetup} alt="imagem ilustrativa"/>
               </div>
               </div>
               <br/>
               <div className='conteudo'>
                <h4>Descubra já o que é predominante na sua personalidade</h4>
                <p>Faça o teste comportamental agora !!</p><br/>
                <img src={imgdisc} alt="imagem ilustrativa"/>
                <Button value='Faça já o seu'/>
               </div>
        </div>
    )
}
export default  dashboard