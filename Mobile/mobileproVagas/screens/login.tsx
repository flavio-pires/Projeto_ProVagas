import React, { useState } from 'react';
import {AsyncStorage } from 'react-native'
import { StackScreenProps } from '@react-navigation/stack'
import {Alert, StyleSheet, Text, View, Image, TextInput, TouchableOpacity } from 'react-native';
import { RootStackParamList } from '../types';



export default function LoginScreen({
  navigation,
}: StackScreenProps<RootStackParamList, 'NotFound'>) {

  // clicou = () => {
  //   Alert.alert("ProVagas", "Você clicou!")
  // }
  

    const [email, setemail] = useState('')
    const [senha, setsenha] = useState('')

    const [role, setrole] = useState('')


    const decodeToken = async () => {
      var token = await AsyncStorage.getItem('token');
  
      var jwtDecode = require('jwt-decode');
  
      var tokenDecoded = jwtDecode(token);
  
      setrole(tokenDecoded.Role);
    }


    const login = () => {
        const login ={
            email: email,
            senha: senha
        }

        fetch('http://localhost:5000/api/login', {
            method: 'POST',
            body: JSON.stringify(login),
            headers: {
                'content-type':'application/json'
            }
        })

        .then(resp => resp.json())
        .then(data =>{
            if (data.value.token != undefined) 
            {
                AsyncStorage.setItem('token', data.value.token)
                
                if (role === 'Empresa') 
                {
                    navigation.navigate ('dashboarduser');
                }  
                // if (role === 'Candidato') 
                // {
                //     history.push('/dashboarduser');
                // }
            }
            else {
                alert('Email ou senha incorretos');
            }
        })
        .catch(e => console.error(e));
    }


  return (
    <View style={styles.container}>

      <Text style={styles.titleLogin}>Bem-vindo!</Text>
      <Image 
      source={require('../assets/images/img_login.png')}
      style={styles.banner}
      />
      
      <TextInput
      style={styles.inputLogin}
      placeholder="Digite seu email.."
      onChangeText={text => setsenha(text)}
      />
      <TextInput
      style={styles.inputLogin}
      secureTextEntry={true}
      placeholder="Digite sua senha.."
      onChangeText={text => setemail(text)}
      />
      <TouchableOpacity
        style={styles.btnLogin}
       
      >
      <Text style={styles.textBtnLogin}>Login</Text>
      </TouchableOpacity>
      
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#ffffff'
  },
  titleLogin: {
    marginBottom: 50,
    marginTop: -100,
    fontSize: 16,
    fontWeight: "bold"
  },
  banner: {
    width: 135,
    height: 135,
    marginBottom: 40,
    borderRadius: 20
  }, 
  inputLogin: {
    marginTop: 10,
    width: 300,
    fontSize: 16,
    borderRadius: 4,
    padding: 10,
    borderBottomWidth: .8,
    borderTopWidth: .8,
    borderLeftWidth: .8,
    borderRightWidth: .8
    // shadowColor: '#470000',
    // shadowOffset: {width: 0, height: 2},
    // shadowOpacity: 0.25,
    // shadowRadius: 3.84,
    // elevation: 3,
  },
  btnLogin: {
    width:300,
    height: 48,
    backgroundColor: "#ED1F24",
    marginTop: 30,
    borderRadius: 4,
    alignItems: 'center',
    justifyContent: 'center'

  },
  textBtnLogin: {
    fontSize: 16,
    color: "#fff",
    fontWeight: "bold"
  }
});