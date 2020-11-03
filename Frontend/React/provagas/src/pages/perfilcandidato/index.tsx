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
                            <Input name='Nome' label='Nome' placeholder='Ex: Hebert Richard'/>
                        </div>
                        <div className='hb'>
                            <Input name='Sobrenome' label='Sobrenome' placeholder='Ex: Kong'/>
                        </div>
                        <div className='hb'>
                            <Input name='E-mail' label='E-mail' placeholder='Ex: hebertrichard@gmail.com'/>
                        </div>
                <div className='habilidades'>
                    <br/>
                <h3>Habilidades</h3>
                    <br/>
                <select id="Hablidades">
                <option value="" disabled selected>Selecione</option>
                <option value="C#">C#</option>
                <option value="JavaScript">JavaScript</option>
                <option value="ReactJs">ReactJs</option>
                </select>
                </div>
                    </form>                 
                </div>
                <div className='right'>
                <form>
                    <div className='bh'>
                    <Input name='Telefone' label='Telefone' placeholder='Ex: (11) 970707070'/>
                    </div>
                    <div className='bh'>
                    <Input name='Cidade' label='Cidade' placeholder='Ex: São Paulo'/>
                    </div>
                    <div className='bh'>
                    <Input name='Github' label='Github' placeholder='Ex: https://github.com/GustavoCasco'/>
                    </div>
                    <div className='aceita'>
                    <br/>
                    <h3>Aceita trabalho remoto ?</h3>
                    <br/>
                        <select >
                        <option value="" disabled selected>Selecione</option>
                        <option value="sim">Sim</option>
                        <option value="nao">Não</option>
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