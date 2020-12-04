import { StackScreenProps } from '@react-navigation/stack';
import React from 'react';
import { TouchableOpacity } from 'react-native';
import { View, Image, StyleSheet, Text } from 'react-native';
import { RootStackParamList } from '../types';

export default function Inicio({
    navigation,
  }: StackScreenProps<RootStackParamList, 'NotFound'>){


  
    return (
        <View style={styles.container}>
            <View style={styles.card}>
                <View  style={styles.center}>

                <Text style={{fontWeight:"bold",fontSize:18}}>
                    Bem Vindo ao ProVagas !
                </Text>
                </View>
                 <View  style={styles.slogan}>

                <Text >
                    Pensado para empresas, pensado para candidatos !
                </Text>
                </View>


                <View >
                <Image
                   style={{ width: 250, height: 150, marginBottom: '15%', marginTop: 50}}
                   source={require('../assets/images/work.png')}

                />
                </View>

                    <TouchableOpacity
                     style={styles.btnEntar}
                    onPress={ () => navigation.navigate('Login') }
                      >
                     <Text style={styles.textBtnEntrar}>Entrar</Text>
                    </TouchableOpacity>
            </View>
    
        </View>
      );
    
}

const styles = StyleSheet.create({
    container: {
       flex: 0.3,
    backgroundColor: '#ED1F24',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
     } ,
     card:{
        height:570,
        width:"87%",
        backgroundColor:"white",
        borderRadius:15,
        elevation:10,
        padding:10,
        marginTop: 580,
      },
      center: {
        alignItems: 'center',
        justifyContent: 'center',
        padding: 20
        
      },
      slogan: {
          alignItems: 'center',
          justifyContent: 'center',
          padding: 24,    
           
      },
    
      btnEntar:
      {
        width:180,
        height: 40,
        backgroundColor: "#ED1F24",
        marginTop: 60,
        marginLeft: 35,
        borderRadius: 4,
        alignItems: 'center',
        justifyContent: 'center'
      
      },

      textBtnEntrar: {
        fontSize: 12,
        color: "#fff",
        fontWeight: "bold"
      }

    });