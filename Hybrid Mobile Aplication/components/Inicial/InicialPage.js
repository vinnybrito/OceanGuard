import { View, Text, Image, TouchableOpacity } from 'react-native';
import { useNavigation } from '@react-navigation/native';
import React, { useState, useEffect } from 'react';
import Login1 from '../../assets/login1.png';
import Login2 from '../../assets/login2.png';
import Login3 from '../../assets/login3.png';
import estilos from './estilos';

const slides = [
  {
    image: Login1,
    backgroundColor: '#ffffff',
    mainText: 'Junte-se a nós na\nproteção dos oceanos!',
    subText: 'Contribua com a limpeza\ndo planeta terra',
  },
  {
    image: Login2,
    backgroundColor: '#ffffff',
    mainText: 'Faça a diferença\nCom o OceanGuard',
    subText: 'Proteja as praias e os oceanos\num clique de cada vez!',
  },
  {
    image: Login3,
    backgroundColor: '#ffffff',
    mainText: 'Torne-se um Guardião\nDos Mares!',
    subText: 'Ajude a preservar a vida marinha\ne manter nossos oceanos limpos',
  },
];

const InicialPage = () => {
  const [activeIndex, setActiveIndex] = useState(0);
  const navigation = useNavigation(); 

  useEffect(() => {
    const interval = setInterval(() => {
      setActiveIndex((prevIndex) => (prevIndex + 1) % slides.length);
    }, 3000); // Muda o slide a cada 3 segundos

    return () => clearInterval(interval); // Limpa o intervalo ao desmontar
  }, []);

  const changeSlide = (index) => {
    setActiveIndex(index);
  };

  const handleLoginPress = () => {
    navigation.navigate('LoginScreen'); 
  };

  const handleRegisterPress = () => {
    navigation.navigate('RegisterScreen');
  };

  return (
    <View style={[estilos.container, { backgroundColor: slides[activeIndex].backgroundColor }]}>
      <View style={estilos.imageContainer}>
        <Image source={slides[activeIndex].image} style={estilos.image} />
        <Text style={estilos.text}>
          {slides[activeIndex].mainText}
        </Text>
        <Text style={estilos.subText}>
          {slides[activeIndex].subText}
        </Text>
      </View>
      <View style={estilos.slideShow}>
        {slides.map((_, index) => (
          <TouchableOpacity key={index} onPress={() => changeSlide(index)}>
            <View style={[
              estilos.slideIcon,
              activeIndex === index ? estilos.activeSlideIcon : estilos.inactiveSlideIcon
            ]} />
          </TouchableOpacity>
        ))}
      </View>
      <View style={estilos.buttonContainer}>
        <TouchableOpacity onPress={handleLoginPress} style={estilos.button}>
          <Text style={estilos.buttonText}>Login</Text>
        </TouchableOpacity>
        <TouchableOpacity onPress={handleRegisterPress} style={estilos.button}>
          <Text style={estilos.buttonText}>Cadastre-se</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};

export default InicialPage;
