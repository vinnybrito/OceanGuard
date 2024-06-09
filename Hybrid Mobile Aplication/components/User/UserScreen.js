import React, { useState, useEffect } from 'react';
import { View, Text, TouchableOpacity, Image, FlatList, ScrollView } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { auth } from '../../config/firebase';
import { Ionicons } from '@expo/vector-icons';
import estilos from './estilos';
import Footer from '../Rodape/Footer';

export default function UserScreen({ navigation }) {
    const [userName, setUserName] = useState('');
    const [userEmail, setUserEmail] = useState('');

    useEffect(() => {
        const fetchUserData = async () => {
            const name = await AsyncStorage.getItem('userName');
            const email = await AsyncStorage.getItem('userEmail');
            setUserName(name || 'Usuário');
            setUserEmail(email || 'email@example.com');
        };
        fetchUserData();
    }, []);

    const handleLogout = async () => {
        try {
            await auth.signOut();
            navigation.navigate('InicialPage');
        } catch (error) {
            console.error('Erro ao fazer logout:', error);
        }
    };

    const configurations = [
        { key: '1', title: 'Alterar senha' },
        { key: '2', title: 'Atualizar email' },
        { key: '3', title: 'Excluir conta' },
        { key: '4', title: 'Notificações' },
        { key: '5', title: 'Localização em tempo real' }
    ];

    const quickLinks = [
        { key: '1', title: 'Meus registros', screen: 'MeusRegistros' },
        { key: '2', title: 'Nova ocorrência', screen: 'FazerRegistro' },
    ];

    return (
        <View style={estilos.container}>
            <View style={estilos.header}>
                <Image source={require('../../assets/user.png')} style={estilos.userIcon} />
                <Text style={estilos.headerText}>{userName}</Text>
                <TouchableOpacity onPress={handleLogout}>
                    <Ionicons name="log-out" style={estilos.logoutButtonIcon} />
                </TouchableOpacity>
            </View>
            <ScrollView style={estilos.scrollView}>
                <View style={estilos.profileInfoContainer}>
                    <Text style={estilos.profileInfoTitle}>Informações do Perfil</Text>
                    <Text style={estilos.profileInfoItem}><Text style={estilos.profileInfoLabel}>Nome:</Text> {userName}</Text>
                    <Text style={estilos.profileInfoItem}><Text style={estilos.profileInfoLabel}>Email:</Text> {userEmail}</Text>
                </View>

                <View style={estilos.configurationsContainer}>
                    <Text style={estilos.configurationsTitle}>Configurações da conta</Text>
                    <FlatList
                        data={configurations}
                        renderItem={({ item }) => (
                            <TouchableOpacity style={estilos.configurationItem}>
                                <Text style={estilos.configurationItemText}>{item.title}</Text>
                            </TouchableOpacity>
                        )}
                        keyExtractor={item => item.key}
                    />
                </View>

                <View style={estilos.quickLinksContainer}>
                    <Text style={estilos.quickLinksTitle}>Atalhos Rápidos</Text>
                    <FlatList
                        data={quickLinks}
                        renderItem={({ item }) => (
                            <TouchableOpacity 
                                style={estilos.quickLinkItem}
                                onPress={() => navigation.navigate(item.screen)}
                            >
                                <Text style={estilos.quickLinkItemText}>{item.title}</Text>
                            </TouchableOpacity>
                        )}
                        keyExtractor={item => item.key}
                    />
                </View>
            </ScrollView>
            <Footer />
        </View>
    );
}