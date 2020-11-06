import React, { InputHTMLAttributes } from 'react'
import './style.css'


interface SelectProps extends InputHTMLAttributes<HTMLInputElement>{
    name: string;
    options: any[], 
    labelText: string,
    callbackChangedValue:(value: any) => void
}


export default function Select(props: SelectProps){

    const {name, options, labelText, callbackChangedValue} = props;

    return (
        <div className="">
            <div className="box-select-label">
            <label htmlFor={name}>{labelText}</label>
            <select className="select-input" id={name} onChange={(event) => {
                callbackChangedValue(event.target.value)
            }}>
                <option defaultValue="selected">Selecione</option>
                {options.map((o, i) => <option key={i} value={o}>{o}</option>)
                }
            </select>
            </div>
        </div>
    )
}