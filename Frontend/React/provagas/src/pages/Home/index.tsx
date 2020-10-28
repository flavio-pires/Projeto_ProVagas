import React from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';


function Home(){
    return(
        <div className="centro">
            <div className="home">
                <Header/>
                <Footer/>
            </div>
        </div>
    );
}

export default Home;