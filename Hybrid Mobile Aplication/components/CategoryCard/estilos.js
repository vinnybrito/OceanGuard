import { StyleSheet } from 'react-native';

export default StyleSheet.create({
  cardContainer: {
    width: '100%',
    borderRadius: 15,
    overflow: 'hidden',
    marginVertical: 10,
  },
  card: {
    backgroundColor: 'rgba(255, 255, 255, 0)', 
    borderRadius: 15,
    borderWidth: 1,
    borderColor: '#e6e6e6',
    padding: 20,
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  cardContent: {
    flex: 1,
    marginRight: 10,
  },
  cardTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333',
  },
  cardDescription: {
    fontSize: 16,
    color: '#666',
    marginVertical: 10,
  },
  cardDescriptionEstatisticas: {
    fontSize: 24,
    color: '#fff',
    fontWeight: 'bold',
    marginVertical: 21,
  },
  button: {
    backgroundColor: '#fff',
    borderRadius: 25,
    paddingVertical: 10,
    paddingHorizontal: 20,
    alignItems: 'center',
    justifyContent: 'center',
    maxWidth: '96%', 
  },
  buttonText: {
    fontSize: 16,
    fontWeight: 'bold',
  },
  cardImage: {
    width: 120,
    height: 120,
  },
});