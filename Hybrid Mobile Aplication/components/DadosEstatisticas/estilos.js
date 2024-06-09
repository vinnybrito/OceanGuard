import { StyleSheet} from 'react-native';

export default StyleSheet.create({
    container: {
        flexGrow: 1,
        justifyContent: 'center',
        padding: 20,
        backgroundColor: '#f2f2f2',
      },
      pageTitle: {
        fontSize: 32,
        fontWeight: 'bold',
        marginTop: 40,
        marginBottom: 20,
        color: '#333',
      },
      searchContainer: {
        flexDirection: 'row',
        alignItems: 'center',
        backgroundColor: '#FFF',
        borderRadius: 25,
        paddingVertical: 10,
        paddingHorizontal: 15,
        marginBottom: 20,
      },
      searchIcon: {
        marginRight: 10,
      },
      searchInput: {
        flex: 1,
        fontSize: 16,
        color: '#62CDFA',
      },
});

