// Footer.js
import React from 'react';
import { View, TouchableOpacity, Text } from 'react-native';
import { useNavigation, useRoute } from '@react-navigation/native';
import { Icon } from 'react-native-elements';
import estilos from './estilos';

export default function Footer() {
    const navigation = useNavigation();
    const route = useRoute();

    const navigateToHome = () => {
        navigation.navigate('HomeScreen');
    };

    const navigateToDadosEstatisticasScreen = () => {
        navigation.navigate('DadosEstatisticasScreen');
    };

    const navigateToUser = () => {
        navigation.navigate('UserScreen');
    };

    return (
        <View style={estilos.footer}>
            <TouchableOpacity onPress={navigateToDadosEstatisticasScreen}>
                <Icon
                    name="leaderboard"
                    type="material-icons"
                    size={36}
                    color={route.name === 'DadosEstatisticasScreen' ? '#62CDFA' : 'black'}
                />
                <Text style={[estilos.iconText, route.name === 'DadosEstatisticasScreen' ? estilos.activeText : null]}>Dados</Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={navigateToHome}>
                <Icon
                    name="home"
                    type="material-icons"
                    size={36}
                    color={route.name === 'HomeScreen' ? '#62CDFA' : 'black'}
                />
                <Text style={[estilos.iconText, route.name === 'HomeScreen' ? estilos.activeText : null]}>Home</Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={navigateToUser}>
                <Icon
                    name="person"
                    type="material-icons"
                    size={36}
                    color={route.name === 'UserScreen' ? '#62CDFA' : 'black'}
                />
                <Text style={[estilos.iconText, route.name === 'UserScreen' ? estilos.activeText : null]}>Conta</Text>
            </TouchableOpacity>
        </View>
    );
}
