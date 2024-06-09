import { StyleSheet, Dimensions } from 'react-native';

const larguraDaTela = Dimensions.get('window').width;

export default StyleSheet.create({
  inputContainer: {
    marginBottom: 15,
    position: 'relative',
    width: larguraDaTela * 0.9,
  },
  icon: {
    position: 'absolute',
    left: 15,
    top: 24,
    zIndex: 1,
  },
  eyeIcon: {
    position: 'absolute',
    right: 15,
    top: 24,
    zIndex: 1,
  },
  input: {
    height: 50,
    width: '100%',
    borderColor: "#e6e6e6",
    borderWidth: 1,
    paddingHorizontal: 50,
    marginTop: 10,
    backgroundColor: '#E8E8E8',
  },
  inputError: {
    borderColor: '#d32f2f',
  },
  helperText: {
    position: 'absolute',
    bottom: -25,
    left: 0,
    color: '#d32f2f',
  }
});
