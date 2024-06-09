import React, { useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, TextInput } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useFocusEffect } from '@react-navigation/native';
import Footer from '../Rodape/Footer';
import { Icon } from 'react-native-elements';
import estilos from './estilos';

const MeusRegistros = ({ navigation }) => {
  const [orders, setOrders] = useState([]);

  const fetchOrders = async () => {
    const existingOrders = await AsyncStorage.getItem('orders');
    if (existingOrders) {
      setOrders(JSON.parse(existingOrders));
    }
  };

  useFocusEffect(
    React.useCallback(() => {
      fetchOrders();
    }, [])
  );

  const handleDeleteOrder = async (id) => {
    const filteredOrders = orders.filter(order => order.id !== id);
    setOrders(filteredOrders);
    await AsyncStorage.setItem('orders', JSON.stringify(filteredOrders));
  };

  const handleEditOrder = (order) => {
    navigation.navigate('FazerRegistro', { order });
  };

  const renderItem = ({ item }) => (
    <View style={estilos.orderContainer}>
      <Text style={estilos.orderName}>{item.name}</Text>
      <Text style={estilos.orderDetails}>{item.details}</Text>
      <Text style={estilos.orderQuantity}>Localização: {item.quantity}</Text>
      <View style={estilos.buttonGroup}>
        <TouchableOpacity style={estilos.editButton} onPress={() => handleEditOrder(item)}>
          <Text style={estilos.buttonText}>Editar</Text>
        </TouchableOpacity>
        <TouchableOpacity style={estilos.deleteButton} onPress={() => handleDeleteOrder(item.id)}>
          <Text style={estilos.buttonText}>Excluir</Text>
        </TouchableOpacity>
      </View>
    </View>
  );

  return (
    <View style={estilos.container}>
      <View style={estilos.header}>
        <Text style={estilos.title}>Meus Registros</Text>
      </View>
      <View style={estilos.listContainer}>
        <View style={estilos.searchContainer}>
          <Icon name="search" type="material" color="#62CDFA" style={estilos.searchIcon} />
          <TextInput 
            style={estilos.searchInput}
            placeholder="Buscar registros"
          />
        </View>
        <FlatList
          data={orders}
          renderItem={renderItem}
          keyExtractor={item => item.id}
        />
      </View>
      <Footer />
    </View>
  );
};

export default MeusRegistros;