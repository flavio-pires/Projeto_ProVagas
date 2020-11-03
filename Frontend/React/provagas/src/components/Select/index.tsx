import React, {SelectHTMLAttributes} from 'react';
import './style.css'

interface SelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
    name:string;
    label:string;
    value:string;
}

const select:React.FC<SelectProps> = ({label, name, ...rest}) => {
    return (
        <>
                <label htmlFor={name}></label>
                <select >
                    <option value=''> Selecione</option>
                    <option value={name}></option>
                </select>
        </>
    )
}

export default select