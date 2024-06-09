import React from 'react';
import { View, Text, TextInput, ScrollView } from 'react-native';
import { Icon } from 'react-native-elements';
import estilos from './estilos';
import CategoryCard from '../CategoryCard/CategoryCard';
import Footer from '../Rodape/Footer';

const DadosEstatisticasScreen = () => {
  return (
    <View style={estilos.container}>
      <Text style={estilos.pageTitle}>Dados e estatísticas</Text>
      <View style={estilos.searchContainer}>
        <Icon name="search" type="material" color="#62CDFA" style={estilos.searchIcon} />
        <TextInput 
          style={estilos.searchInput}
          placeholder="Buscar..."
        />
      </View>
      <ScrollView contentContainerStyle={estilos.cardsContainer}>
        <CategoryCard 
          title="Nível do mar"
          description="1.2 metros"
          image={require('../../assets/grafico.png')}
          estatisticas
        />
        <CategoryCard 
          title="Qualidade da água"
          description="Ótima"
          image={require('../../assets/qualidadeAgua.png')}
          estatisticas
        />
        <CategoryCard 
          title="Temperatura"
          description="42 graus"
          image={require('../../assets/temperatura.png')}
          estatisticas
        />
      </ScrollView>
      <Footer />
    </View>
  );
};

export default DadosEstatisticasScreen;
