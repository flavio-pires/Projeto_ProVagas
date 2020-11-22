import React, { useState, useEffect } from 'react';
import Button from '../../components/Button';
import Navleft from '../../components/Navbar/navbar';
import './style.css'
import Input from '../../components/inputPerfil/inputperfil';
import * as AiIcons from 'react-icons/ai';
import {IconContext} from 'react-icons';
import {parseJWT} from '../../services/auth';

export default function perfil (){

    // // const [nome, setNome] = useState('');
    // // const [sobrenome, setsobrenome] = useState('');
    // // const [email, setemail] = useState('');
    // // const [cpf, setcpf] = useState('');
    // // const [telefone, settelefone] = useState('');
    // // const [cidade, setcidade] = useState('');
    // // const [github, setgithub] = useState('');
    // // const [trabremoto, settrabremoto] = useState('');

    // // useEffect (() => {
    // //     listar();
    // // })




    // const listar = () => {
    //     fetch('http://localhost:5000/api/candidatos/buscarporid', {
    //         method: 'GET',
    //         headers: {
    //             authorization: 'Bearer ' + localStorage.getItem('token')
    //         }
    //     })
    //         .then(response => response.json())
    //         .then(dados => {
    //             setNome(dados.NomeCompletoCandidato);
    //             setcpf(dados.Cpf)
    //             setemail(dados.IdEnderecoNavigation.IdUsuarioNavigation.Email);
    //             settelefone(dados.IdEnderecoNavigation.IdUsuarioNavigation.Telefone);
    //             setcidade(dados.IdEnderecoNavigation.IdCidadeNavigation.NomeCidade);
    //             setgithub(dados.Linkedin);
    //         })
    //         .catch(erro => console.error(erro))
    // }

    return (
        <>
            <Navleft/>
            <h2>Perfil do candidato</h2>
                <br/>
             <form >
            <div className='hebert'>
                <div className='left'>
                        <div className='hb'>
                            <Input name='Nome' 
                            label='Nome Completo' 
                            />
                        </div>
                        <div className='hb'>
                            <Input name='CPF' 
                            label='CPF'
                             />
                        </div>
                        <div className='hb'>
                            <Input name='E-mail'
                             label='E-mail'
                             />
                        </div>
                </div>
                <div className='right'>
                    <div className='bh'>
                    <Input name='Telefone'
                     label='Telefone' 
                     />
                    </div>
                    <div className='bh'>
                    <Input name='Cidade' 
                    label='Cidade'
                    />
                    </div>
                    <div className='bh'>
                    <Input name='Github'
                     label='Github'
                     />
                    </div>
                </div>
            </div>
         </form>                 
                <div className='btnao'> 
                <Button value='Enviar'/>
                </div>
            
        </>
    )
}