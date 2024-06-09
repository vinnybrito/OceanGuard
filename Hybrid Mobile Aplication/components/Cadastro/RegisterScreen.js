import React, { useState } from 'react';
import {
  Text,
  TouchableOpacity,
  Alert,
  KeyboardAvoidingView,
  Platform,
  View,
} from 'react-native';
import { EntradaTexto } from '../../components/EntradaTexto';
import estilos from './estilos';
import { cadastrar } from '../../servicos/requisicoesFirebase';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function RegisterScreen({ navigation }) {
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [confirmaSenha, setConfirmaSenha] = useState('');
  const [statusError, setStatusError] = useState('');
  const [mensagemError, setMensagemError] = useState('');

  async function realizarCadastro() {
    if (nome === '') {
      setMensagemError('Preencha o campo Nome');
      setStatusError('nome');
    } else if (email === '') {
      setMensagemError('Preencha o campo E-Mail');
      setStatusError('email');
    } else if (senha === '') {
      setMensagemError('Preencha o campo senha');
      setStatusError('senha');
    } else if (confirmaSenha === '') {
      setMensagemError('Preencha o campo confirmar senha');
      setStatusError('confirmaSenha');
    } else if (confirmaSenha !== senha) {
      setMensagemError('As senhas devem ser iguais');
      setStatusError('confirmaSenha');
      Alert.alert('As senhas devem ser iguais');
    } else {
      const resultado = await cadastrar(email, senha);
      if (resultado === 'sucesso') {
        await AsyncStorage.setItem('userName', nome);
        Alert.alert('Usuário cadastrado com sucesso');
        setEmail('');
        setSenha('');
        setConfirmaSenha('');
        setNome('');
      } else {
        Alert.alert(resultado);
      }
      
      setStatusError('');
      setMensagemError('');
    }
  }

  return (
    <KeyboardAvoidingView
      style={estilos.container}
      behavior={Platform.OS === 'ios' ? 'padding' : null}
      keyboardVerticalOffset={Platform.OS === 'ios' ? 50 : 0}
    >
      <View style={estilos.content}>
        <Text style={estilos.title}>Cadastro</Text>
        <Text style={estilos.subtitle}>Crie sua conta com segurança</Text>
        <View contentContainerStyle={estilos.scrollContainer}>
          <EntradaTexto
            label="Nome completo"
            value={nome}
            icon="person"
            onChangeText={(text) => setNome(text)}
            error={statusError === 'nome'}
            messageError={mensagemError}
          />
          <EntradaTexto
            label="Email"
            value={email}
            icon="email"
            onChangeText={(text) => setEmail(text)}
            error={statusError === 'email'}
            messageError={mensagemError}
          />
          <EntradaTexto
            label="Senha"
            value={senha}
            icon="lock"
            onChangeText={(text) => setSenha(text)}
            error={statusError === 'senha'}
            secureTextEntry
            messageError={mensagemError}
          />
          <EntradaTexto
            label="Confirmar Senha"
            value={confirmaSenha}
            icon="lock"
            onChangeText={(text) => setConfirmaSenha(text)}
            error={statusError === 'confirmaSenha'}
            secureTextEntry
            messageError={mensagemError}
          />
          <TouchableOpacity
            style={estilos.loginButton}
            onPress={realizarCadastro}
          >
            <Text style={estilos.loginButtonText}>Cadastrar</Text>
          </TouchableOpacity>
          <View style={estilos.registerLink}>
            <Text style={estilos.registerLinkText}>Já tem uma conta?</Text>
            <TouchableOpacity onPress={() => navigation.navigate('LoginScreen')}>
              <Text style={estilos.registerButtonText}>Login</Text>
            </TouchableOpacity>
          </View>
        </View>
      </View>
    </KeyboardAvoidingView>
  );
}
