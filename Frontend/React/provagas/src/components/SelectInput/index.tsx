import React, { InputHTMLAttributes } from 'react'
import './style.css'


interface SelectProps extends InputHTMLAttributes<HTMLInputElement>{
    name: string;
    options: Array<any>, 
    labelText: string,
    callbackChangedValue:(value: any) => void
}


export default function Select(props: SelectProps){

    const {name, options, labelText, callbackChangedValue} = props;

    
    console.log("Optios aqui: ", options)
    return (
        <div className="">
            <div className="box-select-label">
            <label htmlFor={name}>{labelText}</label>
            <select className="select-input" id={name} onChange={(event) => {
                // callbackChangedValue(event.target)
                // console.log(event.target.enterKeyHint)
                console.log(event)
            }}>
                <option defaultValue="selected">Selecione</option>
                {options.map((o) => <option key={o.idPropriedade} value={o.nomePropriedade}>{o.nomePropriedade}</option>)
                }
            </select>
            </div>
        </div>
    )
}