import React, { useState } from 'react';
import { View, Alert, Text, TouchableOpacity, KeyboardAvoidingView} from 'react-native';
import { logar } from '../../servicos/requisicoesFirebase';
import { EntradaTexto } from '../../components/EntradaTexto';
import estilos from './estilos';
import { Platform } from 'react-native';

export default function LoginScreen({ navigation }) {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [statusError, setStatusError] = useState('');
  const [menssagemError, setMenssagemError] = useState('');

  async function realizarLogin() {
    if (email == '') {
      setMenssagemError('O E-Mail é obrigatório!');
      setStatusError('email');
    } else if (senha == '') {
      setMenssagemError('A senha é obrigatória!');
      setStatusError('senha');
    } else {
      const resultado = await logar(email, senha);
      if (resultado == 'erro') {
        setStatusError('firebase')
        setMenssagemError('E-Mail ou senha incorretos.')
        Alert.alert("E-Mail ou senha inválidos!")
      } else {
        navigation.replace('HomeScreen')
      }
    }
  }

  return (
    <KeyboardAvoidingView
      behavior={Platform.OS === 'ios' ? 'padding' : null}
      keyboardVerticalOffset={Platform.OS === 'ios' ? 50 : 0}
      style={estilos.container}
    >
      <View style={estilos.content}>
        <Text style={estilos.title}>Login</Text>
        <Text style={estilos.subtitle}>Faça login com segurança na sua conta</Text>
        <View style={estilos.formContainer}>
          <EntradaTexto
            label="E-mail"
            value={email}
            onChangeText={texto => setEmail(texto)}
            error={statusError == 'email'}
            messageError={menssagemError}
            icon="email"
          />
          <EntradaTexto
            label="Senha"
            value={senha}
            onChangeText={texto => setSenha(texto)}
            secureTextEntry
            error={statusError == 'senha'}
            messageError={menssagemError}
            icon="lock"
          />
          <TouchableOpacity onPress={() => realizarLogin()} style={estilos.loginButton}>
            <Text style={estilos.loginButtonText}>Entrar</Text>
          </TouchableOpacity>
          <View style={estilos.registerLink}>
            <Text style={estilos.registerLinkText}>Ainda não tem uma conta?</Text>
            <TouchableOpacity onPress={() => { navigation.navigate('RegisterScreen') }}>
              <Text style={estilos.registerButtonText}>Registre-se</Text>
            </TouchableOpacity>
          </View>
          <Text style={estilos.termsText}>By clicking Continue, you agree to our Terms of Service and Privacy Policy</Text>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}
