import { StyleSheet } from 'react-native';

export default StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  imageContainer: {
    alignItems: 'center',
  },
  image: {
    width: 310,
    height: 310,
  },
  text: {
    fontSize: 24,
    fontWeight: 'bold', 
    textAlign: 'center',
    marginTop: 20, // Espaçamento adicional
  },
  subText: {
    fontSize: 16,
    textAlign: 'center',
    marginTop: 10, // Espaçamento adicional
  },
  slideShow: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: 20,
  },
  slideIcon: {
    width: 20,
    height: 6,
    borderRadius: 3,
    marginHorizontal: 3,
  },
  activeSlideIcon: {
    backgroundColor: '#5DCCFC',
  },
  inactiveSlideIcon: {
    backgroundColor: '#d3d3d3',
  },
  buttonContainer: {
    marginTop: 80,
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
  },
  button: {
    backgroundColor: '#5DCCFC',
    borderRadius: 10,
    margin: 10,
    alignItems: 'center',
    justifyContent: 'center',
    borderWidth: 2,
    borderColor: 'white',
    width: 320,
    height: 60,
  },
  buttonText: {
    color: 'white',
    fontWeight: 'bold',
  },
});
