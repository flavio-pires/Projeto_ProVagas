import React, { ChangeEvent } from 'react';
import '../../assets/global.css';
import './style.css';

interface ButtonProps {
  value: string;
  id?: string;
}

const Button: React.FunctionComponent<ButtonProps> = ({value, id}) => {
  return (
    <div className="btn">
      <input className="button" type="submit" value={value} id={id}/>
    </div>
  );
}

export default Button;