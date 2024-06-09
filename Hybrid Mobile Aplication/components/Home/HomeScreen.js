import React, { useEffect, useState } from 'react';
import { Text, View, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation } from '@react-navigation/native';
import estilos from './estilos';
import Footer from '../Rodape/Footer';
import CategoryCard from '../CategoryCard/CategoryCard';
import { Icon } from 'react-native-elements';

export default function HomeScreen() {
  const [userName, setUserName] = useState('');
  const [recordCount, setRecordCount] = useState(0);
  const navigation = useNavigation(); 

  useEffect(() => {
    const fetchUserName = async () => {
      const name = await AsyncStorage.getItem('userName');
      setUserName(name || 'Usuário');
    };

    const fetchRecordCount = async () => {
      const records = await AsyncStorage.getItem('orders');
      const orders = records ? JSON.parse(records) : [];
      setRecordCount(orders.length);
    };

    fetchUserName();
    fetchRecordCount();
  }, []);

  const handleRegisterPress = () => {
    navigation.navigate('FazerRegistro'); 
  };

  const handleRegistrosPress = () => {
    navigation.navigate('MeusRegistros'); 
  };

  return (
    <View style={estilos.outerContainer}>
      <View style={estilos.container}>
        <View style={estilos.header}>
          <View>
            <Text style={estilos.greeting}>Bem-vindo</Text>
            <Text style={estilos.username}>{userName}</Text>
          </View>
          <TouchableOpacity style={estilos.notificationIcon}>
            <Icon name="notifications" size={34} color="#62CDFA" />
          </TouchableOpacity>
        </View>
        <CategoryCard
          title="Lixo"
          description="reportar áreas com alta concentração de lixo"
          image={require('../../assets/trash.png')}
          showButton={true}
          onPress={handleRegisterPress}
        />
        <CategoryCard
          title="Animais"
          description="Reportar animais marinhos presentes na praia"
          image={require('../../assets/fish.png')}
          showButton={true}
          onPress={handleRegisterPress}
        />
        <TouchableOpacity style={[estilos.myRecordsButton, estilos.shadow]} onPress={handleRegistrosPress}>
          <Text style={estilos.myRecordsButtonText}>Meus Registros</Text>
        </TouchableOpacity>
        <Text style={estilos.recordsInfo}>
          Você possui {recordCount} registro(s). Informe-nos sobre novas ocorrências.
        </Text>
      </View>
      <Footer />
    </View>
  );
}
