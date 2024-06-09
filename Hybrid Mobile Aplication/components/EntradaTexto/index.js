import { useState } from 'react';
import { TextInput, HelperText } from 'react-native-paper';
import { View, TouchableOpacity } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import estilos from './estilos';

export function EntradaTexto({ label, value, onChangeText, secureTextEntry, error, messageError, icon }) {
  const [secureMode, setSecureMode] = useState(secureTextEntry);

  return (
    <View style={estilos.inputContainer}>
      {icon && <MaterialIcons name={icon} size={24} color="#62CDFA" style={estilos.icon} />}
      <TextInput
        label={label}
        value={value}
        error={error}
        secureTextEntry={secureMode}
        onChangeText={onChangeText}
        style={[estilos.input, error ? estilos.inputError : null]}
        mode="flat"
        activeOutlineColor='#62CDFA'
        underlineColor="transparent"
        selectionColor="#62CDFA"
      />
      {secureTextEntry && (
        <TouchableOpacity style={estilos.eyeIcon} onPress={() => setSecureMode(!secureMode)}>
          <MaterialIcons name={secureMode ? 'visibility-off' : 'visibility'} size={24} color="#62CDFA" />
        </TouchableOpacity>
      )}
      {error && <HelperText type="error" visible={error} style={estilos.helperText}>
        {messageError}
      </HelperText>}
    </View>
  );
}
