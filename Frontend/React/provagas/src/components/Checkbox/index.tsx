import React, { useState } from 'react'

// export default function ComponentCHeckBox({ values, callbackValue }) {

//     return values.map((v, i) => {
//         return (
//             <div key={i}>
//                 <label htmlFor="v">{v}</label>
//                 <input
//                     type="checkbox" 
//                     value={v} 
//                     onChange={event => {
//                         callbackValue({
//                             value: v,
//                             checked: event.target.checked
//                         })
//                     }}
//                 />
//             </div>
//         )
//     })   
// }