import React from 'react';
import Button from '../../components/Button';
import Navleft from '../../components/Navbar/navbar';
import './style.css'
import Input from '../../components/inputPerfil/inputperfil';
import * as AiIcons from 'react-icons/ai';
import {IconContext} from 'react-icons'


export default function perfil (){
    return (
        <>
            <Navleft/>
            <h2>Perfil</h2>
                <div className='hs'>
                    <div className='foto'>
                    </div>
                    <div className='circulo'>
                        <IconContext.Provider value ={{color: "#ED1F24" , size: "1.5em"}}>
                           <AiIcons.AiFillPlusCircle/>
                        </IconContext.Provider>
                    </div>
                    
                    <br/>
                    <p>Editar foto</p>              
                </div>

                <br/>
            <div className='centra'>
                <div className='left'>
                    <form >
                        <div className='hb'>
                            <Input name='Razão Social' label='Razão Social' placeholder='Ex: BRQ SOLUÇÕES EM INFORMATICA'/>
                        </div>
                        <div className='hb'>
                            <Input name='Nome Fantasia' label='Nome Fantasia' placeholder='Ex: BRQ'/>
                        </div>
                        <div className='hb'>
                            <Input name='E-mail' label='E-mail' placeholder='Ex: brq@gmail.com'/>
                        </div>
                        <div className='hb'>
                            <Input name='Nome para contato' label='Nome para contato' placeholder='Ex: Gabriel'/>
                        </div>
                    </form>                 
                </div>
                <div className='right'>
                <form>
                    <div className='bh'>
                    <Input name='CNPJ' label='CNPJ' placeholder='Ex: 36.542.025/0001-64'/>
                    </div>
                    <div className='bh'>
                    <Input name='CNAE' label='CNAE' placeholder='Ex: 6204-0/00'/>
                    </div>
                    <div className='bh'>
                    <Input name='Linkedin' label='Linkedin' placeholder='Ex: https://www.linkedin.com/company/brq/?originalSubdomain=br'/>
                    </div>
                    <div className='aceita'>    
                    <label> Porte da empresa</label>
                   <br/>
                   <br/>
                        <select >
                        <option value="" disabled selected>Selecione</option>
                        <option value="grande">Grande</option>
                        <option value="medio">Médio</option>
                        <option value="pequeno">Pequeno</option>
                        </select>
                    </div>
                </form>
                </div>
            </div>
                <div className='btnao'> 
                <Button value='Enviar'/>
                </div>
            
        </>
    )
}