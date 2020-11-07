import React, { useState } from 'react';
import Button from '../../components/Button';
import Header from '../../components/Header';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import imgcolaborador from '../../components/logoSenai.png'

export default function business() {

    const [nomefantasia, setnomefantasia] = useState('');
    const [razaoSocial, setrazaosocial] = useState('');
    const [nomeContato, setnomecontato] = useState('');
    const [Linkedin, setlinkedin] = useState('');
    const [Website, setWebsite] = useState('');
    const [Cnpj, setcnpj] = useState('');
    const [cnae, setcnae] = useState('');
    const [email,setemail] = useState('');
    const [telefone,settelefone] = useState('');
    const [senha, setsenha] = useState('');

    const save = () => {
        const newbusi = {
            nomeFantasia: nomefantasia,
            razaoSocial: razaoSocial,
            nomeContato: nomeContato,
            linkedin: Linkedin,
            website: Website,
            cnpj: Cnpj,
            cnae: cnae,
            idUsuarioNavigation: {
                email:email,
                senha:senha,
                telefone: telefone,
                idTipoUsuario : 2
           }
        }

        const urlRequest = "http://localhost:5000/api/empresas";

        console.log(newbusi)
  
        fetch(urlRequest, {
            method: "POST",
            body: JSON.stringify(newbusi),
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
       <div className="prcp">
            <Header/>
            <form onSubmit= {event=>{ event.preventDefault();
            save();}}>
                <div className="cadastro">
                    <div className="box-banner-colaborador">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador'/>
                    </div>
                    
                        <h1>Cadastro de Colaboradores</h1>
                        <h4>Dados de acesso</h4>
                        <Input type="email" label ="E-mail" name="email" value={email} onChange={e => setemail(e.target.value)} />
                        <Input type="password" label="Senha" name="senha" value={senha} onChange={e => setsenha(e.target.value)}/>
                        <h4>Informações do Colaborador</h4>
                        <Input type="text" label="Nome Completo" name="nome" onChange={e => setnomefantasia(e.target.value)}/>
                        <Input type="text" label="Unidade Senai" name="senai"  onChange={e => setrazaosocial(e.target.value)}/>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="CPF" name="cpf" onChange={e => setnomecontato(e.target.value)}/>
                            <InputSmaller type="text" label="RG" name="rg" onChange={e => setlinkedin(e.target.value)}/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="CNPJ" name="departamento"  onChange={e => setcnpj(e.target.value)}/>
                            <InputSmaller type="text" label="CNAE" name="nif" onChange={e => setcnae(e.target.value)}/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="date" label="Website" name="datanascimento" onChange={e => setWebsite(e.target.value)}/>
                            <InputSmaller type="tel" label="Tel/Cel" name="Contato" value={telefone} onChange={e => settelefone(e.target.value)}/>
                        </div>

                        <Button value="Finalizar Cadastro" />

                </div>
            </form>
        </div>
    )
}