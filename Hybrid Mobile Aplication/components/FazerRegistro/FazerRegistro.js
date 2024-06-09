import React, { useState, useEffect } from 'react';
import { View, Text, TextInput, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import Footer from '../Rodape/Footer';
import estilos from './estilos';

const FazerRegistro = ({ route, navigation }) => {
  const orderToEdit = route.params?.order;
  const [orderDate, setOrderDate] = useState('');
  const [orderName, setOrderName] = useState('');
  const [orderDetails, setOrderDetails] = useState('');
  const [orderQuantity, setOrderQuantity] = useState('');
  const [errors, setErrors] = useState({});

  useEffect(() => {
    if (orderToEdit) {
      setOrderDate(orderToEdit.date);
      setOrderName(orderToEdit.name);
      setOrderDetails(orderToEdit.details);
      setOrderQuantity(orderToEdit.quantity);
    }
  }, [orderToEdit]);

  const handleAddOrUpdateOrder = async () => {
    let newErrors = {};
    const dateRegex = /^\d{2}\/\d{2}\/\d{4}$/;
    const currentDate = new Date();
    const currentYear = currentDate.getFullYear();

    if (!orderDate.match(dateRegex)) {
      newErrors.orderDate = 'Preencha o campo Data com o formato DD/MM/AAAA';
    } else {
      const [day, month, year] = orderDate.split('/').map(Number);
      if (day > 31 || month > 12 || year > currentYear) {
        newErrors.orderDate = 'Data inválida';
      }
    }

    if (orderName === '') newErrors.orderName = 'Preencha a ocorrência';
    if (orderDetails === '') newErrors.orderDetails = 'Preencha a localização';
    if (orderQuantity === '') newErrors.orderQuantity = 'Preencha a descrição';

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    const newOrder = { 
      id: orderToEdit ? orderToEdit.id : Date.now().toString(), 
      date: orderDate,
      name: orderName, 
      details: orderDetails,
      quantity: orderQuantity 
    };

    const existingOrders = await AsyncStorage.getItem('orders');
    const orders = existingOrders ? JSON.parse(existingOrders) : [];
    
    if (orderToEdit) {
      const updatedOrders = orders.map(order => order.id === newOrder.id ? newOrder : order);
      await AsyncStorage.setItem('orders', JSON.stringify(updatedOrders));
    } else {
      orders.push(newOrder);
      await AsyncStorage.setItem('orders', JSON.stringify(orders));
    }

    setOrderDate('');
    setOrderName('');
    setOrderDetails('');
    setOrderQuantity('');
    setErrors({});
    navigation.navigate('CadastroSucesso', { reload: true });
  };

  const formatDate = (text) => {
    let formattedText = text.replace(/\D/g, ''); 
    if (formattedText.length > 2) {
      formattedText = formattedText.slice(0, 2) + '/' + formattedText.slice(2);
    }
    if (formattedText.length > 5) {
      formattedText = formattedText.slice(0, 5) + '/' + formattedText.slice(5, 9);
    }
    setOrderDate(formattedText);
  };

  return (
    <View style={estilos.container}>
      <Text style={estilos.title}>{orderToEdit ? 'Editar Registro' : 'Registro'}</Text>
      
      <Text style={estilos.label}>Data do ocorrido</Text>
      <TextInput
        style={[estilos.input, errors.orderDate && estilos.inputError]}
        value={orderDate}
        onChangeText={formatDate}
        placeholder="DD/MM/AAAA"
        keyboardType="numeric"
        maxLength={10}
      />
      {errors.orderDate && <Text style={estilos.errorText}>{errors.orderDate}</Text>}
      
      <Text style={estilos.label}>Ocorrência</Text>
      <TextInput
        style={[estilos.input, errors.orderName && estilos.inputError]}
        value={orderName}
        onChangeText={setOrderName} 
      />
      {errors.orderName && <Text style={estilos.errorText}>{errors.orderName}</Text>}
      
      <Text style={estilos.label}>Localização</Text>
      <TextInput
        style={[estilos.input, errors.orderQuantity && estilos.inputError]}
        value={orderQuantity}
        onChangeText={setOrderQuantity}
      />
      {errors.orderQuantity && <Text style={estilos.errorText}>{errors.orderQuantity}</Text>}
      
      <Text style={estilos.label}>Descrição</Text>
      <TextInput
        style={[estilos.input, estilos.detailsInput, errors.orderDetails && estilos.inputError]}
        value={orderDetails}
        onChangeText={setOrderDetails}
        multiline
      />
      {errors.orderDetails && <Text style={estilos.errorText}>{errors.orderDetails}</Text>}
      
      <TouchableOpacity style={estilos.button} onPress={handleAddOrUpdateOrder}>
        <Text style={estilos.buttonText}>{orderToEdit ? "Atualizar Registro" : "Adicionar Registro"}</Text>
      </TouchableOpacity>
      <Footer />
    </View>
  );
};

export default FazerRegistro;
