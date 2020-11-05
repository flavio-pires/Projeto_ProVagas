import React, { useState } from 'react';
import Header from '../../components/Header';
import imgcolaborador from '../../assets/images/imgcadastroadm.png';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import Button from '../../components/Button';
import './style.css';


const

function CadastroAdm(){
    return(
        <div className="prcp">
            <Header/>
            <form>
                <div className="cadastro">
                    <div className="box-banner-colaborador">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador'/>
                    </div>
                    
                        <h1>Cadastro de Colaboradores</h1>
                        <h4>Dados de acesso</h4>
                        <Input type="email" label ="E-mail" name="email" />
                        <Input type="password" label="Senha" name="senha"/>
                        <h4>Informações do Colaborador</h4>
                        <Input type="text" label="Nome Completo" name="nome"/>
                        <Input type="text" label="Unidade Senai" name="senai"/>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="CPF" name="cpf"/>
                            <InputSmaller type="text" label="RG" name="rg"/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="Departamento" name="departamento"/>
                            <InputSmaller type="text" label="Numero do NIF" name="nif"/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="date" label="Data de Nascimento" name="datanascimento"/>
                            <InputSmaller type="tel" label="Tel/Cel" name="Contato"/>
                        </div>

                        <Button value="Finalizar Cadastro"/>

                </div>
            </form>
        </div>


    )
}

export default CadastroAdm;