import React from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header/index';


function Home(){
    return(
        <div className="">
            <div className="home">
                <Header></Header>
                <h1>Pro Vagas</h1>
                <Footer/>
            </div>
        </div>
    );
}

export default Home;