import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';
import InputCnpj from 'react-input-mask'

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
  mask: any;
}

const inputmaskcnpj: React.FunctionComponent<InputProps> = ({mask, label, name, ...rest}) => {
  return (
    <div>
      <div className="box-input-smaller">
        <label htmlFor={name}>{label}</label>
        <InputCnpj  mask=" 99.999.999/9999-99" className="entrada" type="text" id={name} {...rest}/>
      </div>
    </div>
  );
}

export default inputmaskcnpj;