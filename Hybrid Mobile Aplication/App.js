import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import InicialPage from './components/Inicial/InicialPage';
import LoginScreen from './components/Login/LoginScreen';
import RegisterScreen from './components/Cadastro/RegisterScreen';
import HomeScreen from './components/Home/HomeScreen';
import UserScreen from './components/User/UserScreen';
import FazerRegistro from './components/FazerRegistro/FazerRegistro';
import MeusRegistros from './components/MeusRegistros/MeusRegistros';
import CadastroSucesso from './components/CadastroSucesso/CadastroSucesso';
import DadosEstatisticasScreen from './components/DadosEstatisticas/DadosEstatisticasScreen';

const Stack = createStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="InicialPage">
        <Stack.Screen
          name="InicialPage"
          component={InicialPage}
          options={{
            headerShown: false,
          }}
        />
        <Stack.Screen
          name="LoginScreen"
          component={LoginScreen}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="RegisterScreen"
          component={RegisterScreen}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="HomeScreen"
          component={HomeScreen}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="UserScreen"
          component={UserScreen}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="FazerRegistro"
          component={FazerRegistro}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="MeusRegistros"
          component={MeusRegistros}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
        <Stack.Screen
          name="CadastroSucesso"
          component={CadastroSucesso}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
         <Stack.Screen
          name="DadosEstatisticasScreen"
          component={DadosEstatisticasScreen}
          options={({ navigation }) => ({
            headerShown: false,
          })}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;
