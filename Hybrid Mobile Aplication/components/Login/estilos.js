import { StyleSheet, Dimensions } from "react-native";

const larguraDaTela = Dimensions.get('window').width;

export default StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  content: {
    alignItems: 'center',
    marginTop: 80,
    width: larguraDaTela * 0.9,
    paddingBottom: 20,
  },
  title: {
    alignSelf: 'flex-start',
    fontSize: 32,
    fontWeight: 'bold',
    marginBottom: 10,
  },
  subtitle: {
    alignSelf: 'flex-start',
    fontSize: 16,
    color: 'gray',
    marginBottom: 20,
  },
  formContainer: {
    alignItems: 'center',
    width: '100%',
  },
  loginButton: {
    backgroundColor: '#62CDFA',
    height: 50,
    borderRadius: 10,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: 25,
    width: '100%',
  },
  loginButtonText: {
    color: 'white',
    fontWeight: 'bold',
  },
  registerLink: {
    marginTop: 10,
    flexDirection: 'column',
    alignItems: 'center',
  },
  registerLinkText: {
    color: 'black',
    marginBottom: 10,
  },
  registerButtonText: {
    color: '#62CDFA', 
    textDecorationLine: 'underline',
  },
  termsText: {
    color: 'gray',
    textAlign: 'center',
    marginTop: 20,
    fontSize: 12,
  },
});
