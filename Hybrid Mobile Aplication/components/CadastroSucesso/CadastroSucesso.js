import React from 'react';
import { View, Text, Image, TouchableOpacity} from 'react-native';
import { useNavigation } from '@react-navigation/native';
import estilos from './estilos';

const CadastroSucesso = () => {
  const navigation = useNavigation();

  const handleGoToOrders = () => {
    navigation.navigate('MeusRegistros');
  };

  return (
    <View style={estilos.container}>
      <Image source={require('../../assets/obrigado.png')} style={estilos.image} />
      <Text style={estilos.title}>Ocorrência cadastrada com sucesso</Text>
      <Text style={estilos.subtitle}>
        Agradecemos sua contribuição.{"\n"}
        Seu registro foi contabilizado com sucesso!
      </Text>
      <TouchableOpacity style={estilos.button} onPress={handleGoToOrders}>
        <Text style={estilos.buttonText}>Meus registros</Text>
      </TouchableOpacity>
    </View>
  );
};

export default CadastroSucesso;