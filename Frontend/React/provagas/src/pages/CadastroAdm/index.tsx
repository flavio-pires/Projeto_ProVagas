import React, { useState } from 'react';
import Header from '../../components/Header';
import imgcolaborador from '../../assets/images/imgcadastroadm.png';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import Button from '../../components/Button';
import './style.css';





function CadastroAdm(){

    const [nomeAdm, setnomeAdm] = useState('');
    const [nif, setnif] = useState(0);
    const [unisenai, setunisenai] = useState('');
    const [departamento, setdepartamento] = useState('');
    const [email, setemail] = useState('');
    const [senha, setsenha] = useState('');
    const [telefone, settelefone] = useState('');

    const salvarAdm = () => {
        const novoAdm={
            NomeCompletoAdmin:nomeAdm,
            Nif:nif,
            UnidadeSenai:unisenai,
            Departamento:departamento,
                IdUsuarioNavegation:{
                Email:email,
                Telefone:telefone,
                Senha:senha,
                IdTipoUsuario:3
                }
            
            
            
        };
        fetch('http://localhost:5000/api/Administradores',{
            method: 'POST',
            body:JSON.stringify(novoAdm)
        })

        .then((response) => {
            return response.json()
            
        })
        .then (data => console.log(data))
        .catch(err => console.error(err))
        .catch(error=> {
            console.error(error);
            alert("Erro ao cadastrar usuario.");
        });
    }

    // /*const salvarUsuario = () =>{
    //     fetch('http://localhost:5000/api/Usuarios',{
    //         method: 'POST',
    //         body: JSON.stringify({Email:email, Telefone:telefone, Senha:senha, IdTipoUsuario:3})
    //         /*headers:{
    //             authorization : 'Bearer' + localStorage.getItem('token-provagas')
    //         }*/
    //     },
    //     )

    //     .then (response => response.json())
    //     .then(id=>{
    //         salvarAdm(id);
    //     })
    // }

    // const salvarAdm = (id:BigInteger) =>{
    //     const novoAdm={
    //         NomeCompletoAdmin:nomeAdm,
    //         Nif:nif,
    //         UnidadeSenai:unisenai,
    //         Departamento:departamento,
    //         IdUsuario:id
    //     };
    //     fetch('http://localhost:5000/api/Administradores',{
    //         method: 'POST',
    //         body: JSON.stringify(novoAdm)
    //         /*headers:{
    //             authorization : 'Bearer' + localStorage.getItem('token-provagas')
    //         }*/
    //     },
        
    //     )
    //     .then(() => {
    //         alert("Cadastro concluido com sucesso");
    //     })
    //     .catch(error=> {
    //         console.error(error);
    //         alert("Erro ao cadastrar usuario.");
    //     });

    // }/*

    return(
        <div className="prcp">
            <Header/>
            <form action="/" method="post" encType="multipart/form-data" onSubmit= {event=>{ event.preventDefault();
            salvarAdm();}}>
                <div className="cadastro">
                    <div className="box-banner-colaborador">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador'/>
                    </div>
                    
                        <h1>Cadastro de Colaboradores</h1>
                        <h4>Dados de acesso</h4>
                        <Input type="email" label ="E-mail" name="email" value={email} onChange={e => setemail(e.target.value)} />
                        <Input type="password" label="Senha" name="senha" value={senha} onChange={e => setsenha(e.target.value)}/>
                        <h4>Informações do Colaborador</h4>
                        <Input type="text" label="Nome Completo" name="nome" value={nomeAdm} onChange={e => setnomeAdm(e.target.value)}/>
                        <Input type="text" label="Unidade Senai" name="senai" value={unisenai} onChange={e => setunisenai(e.target.value)}/>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="CPF" name="cpf"/>
                            <InputSmaller type="text" label="RG" name="rg"/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="Departamento" name="departamento" value={departamento} onChange={e => setdepartamento(e.target.value)}/>
                            <InputSmaller type="text" label="Numero do NIF" name="nif" value={nif} onChange={e => setnif (parseInt(e.target.value))}/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="date" label="Data de Nascimento" name="datanascimento"/>
                            <InputSmaller type="tel" label="Tel/Cel" name="Contato" value={telefone} onChange={e => settelefone(e.target.value)}/>
                        </div>

                        <Button value="Finalizar Cadastro" />

                </div>
            </form>
        </div>


    )
}

export default CadastroAdm;