import React, { InputHTMLAttributes } from 'react'
import './style.css'


interface SelectProps extends InputHTMLAttributes<HTMLInputElement>{
    name: string;
    options: string[], 
    labelText: string,
    callbackChangedValue:(value: any) => void
}


export default function Select(props: SelectProps){

    const {name, options, labelText, callbackChangedValue} = props;

    return (
        <div className="">
            <label htmlFor={name}>{labelText}</label>
            <select id={name} onChange={(event) => {
                callbackChangedValue(event.target.value)
            }}>
                <option defaultValue="selected">Selecione</option>
                {options.map((o, i) => <option key={i} value={o}>{o}</option>)}
            </select>
        </div>
    )
}