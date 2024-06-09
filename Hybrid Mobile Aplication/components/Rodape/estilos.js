import { StyleSheet, Dimensions } from "react-native";

const { width } = Dimensions.get('window');

export default StyleSheet.create({
    footer: {
      flexDirection: 'row',
      justifyContent: 'space-around',
      backgroundColor: '#fff',
      padding: 0.070 * width, 
      position: 'absolute',
      bottom: 0,
      left: 0,
      right: 0,
    },
    iconText: {
      fontSize: 14,
      color: '#888',
  },
  activeText: {
      color: '#62CDFA',
      fontWeight: 'bold',
  },
  });