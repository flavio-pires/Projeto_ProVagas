import React, { useState } from 'react';
import Input from '../../../components/Input';
import InputSmaller from '../../../components/InputSmaller';
import Button from '../../../components/Button';
import Navbar from '../../../components/Navbar/navbar';
import './style.css';

function PerfilAdm () {
    return(
        <div className="prcp">
            <Navbar/>
                <div className="cadastro">
                    <div className="box-banner-colaborador">
                        <img src={''} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador'/>
                    </div>
                    
                        <h1>Cadastro de Colaboradores</h1>
                        <h4>Dados de acesso</h4>
                        <Input type="email" label ="E-mail" name="email" value={''}  />
                        <Input type="password" label="Senha" name="senha" value={''} />
                        <h4>Informações do Colaborador</h4>
                        <Input type="text" label="Nome Completo" name="nome" value={''} />
                        <Input type="text" label="Unidade Senai" name="senai" value={''} />
                        <div className="input-duplo">
                            <InputSmaller type="text" label="CPF" name="cpf"/>
                            <InputSmaller type="text" label="RG" name="rg"/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="text" label="Departamento" name="departamento" value={''}/>
                            <InputSmaller type="text" label="Numero do NIF" name="nif" value={''}/>
                        </div>
                        <div className="input-duplo">
                            <InputSmaller type="date" label="Data de Nascimento" name="datanascimento"/>
                            <InputSmaller type="tel" label="Tel/Cel" name="Contato" value={''} />
                        </div>

                        <Button value="Finalizar Cadastro" />

                </div>
        </div>
    )
}

export default PerfilAdm;