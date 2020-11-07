import React from 'react';
import '../../assets/global.css';
import './style.css';

interface ButtonProps {
  value: string;
  onclick?: any
}

const Button: React.FunctionComponent<ButtonProps> = ({value, onclick}) => {
  return (
    <div className="btn">
      <input className="button" type="submit" value={value} onClick={event => onclick(event)}/>
    </div>
  );
}

export default Button;