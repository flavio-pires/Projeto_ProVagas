import React, { useState } from 'react';
import Button from '../../components/Button';
import Header from '../../components/Header';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import imgcolaborador from '../../assets/images/imgEmpresa.png';
import './style.css';
import { useHistory } from 'react-router-dom';

export default function Business() {

    let history = useHistory();

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
    const [cep, setCep] = useState('');
    const [rua, setRua] = useState('');
    const [complemento, setComplemento] = useState('');
    const [bairro, setBairro] = useState('');
    const [localidade, setLocalidade] = useState('');
    const [uf, setUf] = useState('');
    const [numero, setNumero] = useState('');

    const save = () => {
        const newbusi = {
            nomeFantasia: nomefantasia,
            razaoSocial: razaoSocial,
            nomeParaContato: nomeContato,
            linkedin: Linkedin,
            website: Website,
            cnpj: Cnpj,
            cnae: cnae,
            idEnderecoNavigation: {
                rua: rua,
                num: numero,
                bairro: bairro,
                complemento: complemento,
                cep: cep,
               idCidadeNavigation: {
                nomeCidade: localidade,
                    IdEstadoNavigation: {
                        nomeEstado: uf
                    }
                },
                        idUsuarioNavigation: {
                            email: email,
                            senha: senha,
                            telefone: telefone,
                            idTipoUsuario : 2
                       }
            }
        }

        const urlRequest = "http://localhost:5000/api/empresas";

        console.log(newbusi)
  
        fetch(urlRequest, {
            method: "POST",
            body: JSON.stringify(newbusi),
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                authorization: 'Bearer' + localStorage.getItem('token-provagas')
            }
        })
            .then((response) => {
                return response.json()         
            })
            .then (data => {
                if (data !== undefined) {
                   alert('Cadastrado') 
                   history.push('/Login')
                  }
                  else{
                    alert('Cadastro inválido');
                  }
            })
            .catch(err => console.error(err));
     }




    //  const listcep = (valor: string) => {
    //     fetch(`https://viacep.com.br/ws/${valor}/json/`, {
    //         method: 'GET',
    //         headers: {
    //             'content-type': 'application/json'
    //         }
    //     })
    //         .then(response => response.json())
    //         .then(dados => {
    //             setCep(dados.cep);
    //             setRua(dados.logradouro);
    //             setBairro(dados.bairro);
    //             setLocalidade(dados.localidade)
    //             setUf(dados.uf)

    //         })
    //         .catch(erro => console.error(erro))
    // }

    return (
       <div className="prcp">
            <Header/>
            <form onSubmit= {event=>{ event.preventDefault();
            save();}}>
                <div className="cadastro">
                    <div className="box-banner-candidato">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador'/>
                    </div>
                    
                        <h1>Cadastro da empresa</h1>
                        <h3>Dados de acesso</h3>
                        <br/>
                            <div className="input-duplo">

                            <Input type="email" 
                            label ="E-mail" 
                            name="email" 
                            onChange={e => setemail(e.target.value)}/>
                            </div>

                            <div className="input-duplo">

                            <Input type="password" 
                            label="Senha"
                             name="senha" 
                             onChange={e => setsenha(e.target.value)}/>
                            </div>

                        <h4>Informações do Colaborador</h4>

                            <div className="input-duplo">
                            <Input type="text"
                             label="Nome Fantasia"
                              name="nome" 
                              onChange={e => setnomefantasia(e.target.value)}/>
                            </div>

                            <div className="input-duplo">

                            <Input type="text"
                             label="Razão Social" 
                             name="senai"  
                             onChange={e => setrazaosocial(e.target.value)}/>
                            </div>

                        <div className="input-duplo">

                            <InputSmaller type="text"
                             label="Nome Para Contato" 
                             name="nc" 
                             onChange={e => setnomecontato(e.target.value)}/>

                            <InputSmaller type="text"
                             label="Linkedin" 
                             name="linkedin" 
                             onChange={e => setlinkedin(e.target.value)}/>

                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="text" 
                            label="CEP"
                             name="cep" 
                             onChange={e => setCep(e.target.value)}
                             />

                            <InputSmaller type="text" 
                            label="Bairro"
                             name="bairro"
                            onChange={e => setBairro(e.target.value)} 
                              />

                        </div>

                        <div className="input-duplo">
                            <Input type="text" 
                            label="Rua"
                             name="Rua" 
                             onChange={e => setRua(e.target.value)}
                            />

                        </div>

                        <div className="input-duplo">
                        
                            <Input type="text" 
                            label="Complemento"
                             name="compl"
                            onChange={e => setComplemento(e.target.value)}/>

                        </div>

                        <div className="input-duplo">
                            <InputSmaller type="text" 
                            label="Estado"
                             name="esta" 
                            onChange={e => setUf(e.target.value)}
                            />

                            <InputSmaller type="text" 
                            label="Cidade"
                             name="Cidade"
                            onChange={e => setLocalidade(e.target.value)}
                           />

                        </div>

                        <div className="input-duplo">

                            <InputSmaller type="text" 
                            label="Numero"
                             name="num"
                            onChange={e => setNumero(e.target.value)}/>

                        </div>

                        <div className="input-duplo">

                            <InputSmaller type="text" 
                            label="CNPJ" 
                            name="cnpj"
                             maxLength={15}  
                             onChange={e => setcnpj(e.target.value)}/>

                            <InputSmaller type="text" 
                            label="CNAE" 
                            name="cnae"
                            maxLength={8}  
                            onChange={e => setcnae(e.target.value)}/>

                        </div>
                        <div className="input-duplo">

                            <InputSmaller type="text"
                             label="Website" 
                             name="web"  
                             onChange={e => setWebsite(e.target.value)}/>

                            <InputSmaller type="tel" 
                            label="Tel/Cel"
                             name="Contato" 
                             onChange={e => settelefone(e.target.value)}/>

                        </div>

                        <Button value="Finalizar Cadastro" />
                </div>
            </form>
        </div>
    )
}