import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
}

const Input: React.FunctionComponent<InputProps> = ({label, name, ...rest}) => {
  return (
    <div>
      <div className="box-input">
        <label htmlFor={name}>{label}</label>
        <input type="text" id={name} {...rest}/>
      </div>
    </div>
  );
}

export default Input;