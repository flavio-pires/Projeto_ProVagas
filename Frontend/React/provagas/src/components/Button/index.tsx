import React from 'react';
import '../../assets/global.css';
import './style.css';

interface ButtonProps {
  value: string;
}

const Button: React.FunctionComponent<ButtonProps> = ({value}) => {
  return (
    <div className="btn">
      <input className="button" type="submit" value={value}/>
    </div>
  );
}

export default Button;