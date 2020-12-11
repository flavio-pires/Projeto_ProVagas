import React, { useEffect, useState } from'react';

function ListarEmpresa(){
  const [idEmpresa, setIdEmpresa] = useState(0);
  const [empresa, setEmpresa] = useState('');

  const [empresas, setEmpresas] = useState([])

  useEffect(()=>{
    listar();
  }, []);

  const listar =() =>{
    fetch('http://localhost:5000/api/administradores/empresa',{
      method: 'GET',
      headers:{
        // authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
      }
    })

    .then(response => response.json())
    .then(dados =>{
      setEmpresas(dados);
    })
    .catch(err => console.error(err));

  }
  return(
    <div>
      <table>
        <h1>Vagas</h1>
        <tbody>
          {
            empresas.map((item:any) => {
              return(
                <tr key={item.idEmpresa}>
                  <td>{item.razaoSocial}</td>
                  <td>{item.nomeFantasia}</td>
                </tr>
              )
            })
          }
        </tbody>
      </table>
    </div>

  )

}

export default ListarEmpresa;