import React, { useState, useEffect } from 'react';
import Button from '../../components/Button';
import Navleft from '../../components/Navbar/navbar';
import './style.css'
import Input from '../../components/inputPerfil/inputperfil';
import * as AiIcons from 'react-icons/ai';
import {IconContext} from 'react-icons';
import {parseJWT} from '../../services/auth';

export default function perfil (){

    const [nome, setNome] = useState('');
    const [sobrenome, setsobrenome] = useState('');
    const [email, setemail] = useState('');
    const [cpf, setcpf] = useState('');
    const [telefone, settelefone] = useState('');
    const [cidade, setcidade] = useState('');
    const [github, setgithub] = useState('');
    const [trabremoto, settrabremoto] = useState('');

    useEffect (() => {
        listar();
    })




    const listar = () => {
        fetch('http://localhost:5000/api/candidatos', {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setNome(dados.NomeCompletoCandidato);
                setcpf(dados.Cpf)
                setemail(dados.IdEnderecoNavigation.IdUsuarioNavigation.Email);
                settelefone(dados.IdEnderecoNavigation.IdUsuarioNavigation.Telefone);
                setcidade(dados.IdEnderecoNavigation.IdCidadeNavigation.NomeCidade);
                setgithub(dados.Linkedin);
            })
            .catch(erro => console.error(erro))
    }

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
                            <Input name='Nome' label='Nome' placeholder={nome}/>
                        </div>
                        <div className='hb'>
                            <Input name='CPF' label='CPF' placeholder={cpf}/>
                        </div>
                        <div className='hb'>
                            <Input name='E-mail' label='E-mail' placeholder={parseJWT.name}/>
                        </div>
                    </form>                 
                </div>
                <div className='right'>
                <form>
                    <div className='bh'>
                    <Input name='Telefone' label='Telefone' placeholder={telefone}/>
                    </div>
                    <div className='bh'>
                    <Input name='Cidade' label='Cidade' placeholder={cidade}/>
                    </div>
                    <div className='bh'>
                    <Input name='Github' label='Github' placeholder={github}/>
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