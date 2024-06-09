import { StyleSheet } from 'react-native';

export default StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#f2f2f2',
    },
    header: {
        flexDirection: 'row',
        alignItems: 'center',
        paddingVertical: 35,
        paddingHorizontal: 15,
        justifyContent: 'space-between',
        backgroundColor: '#5DCCFC',
        borderBottomLeftRadius: 20,
        borderBottomRightRadius: 20,
        elevation: 10,
    },
    headerText: {
        color: '#fff',
        marginTop: 20,
        fontSize: 30,
        fontWeight: 'bold',
    },
    userIcon: {
        marginTop: 20,
        width: 60,
        height: 60,
        borderRadius: 30,
        borderColor: '#fff',
        borderWidth: 2,
    },
    logoutButtonIcon: {
        marginTop: 20,
        color: '#fff',
        fontSize: 30,
    },
    scrollView: {
        flex: 1,
        paddingHorizontal: 10,
    },
    profileInfoContainer: {
        padding: 20,
        margin: 10,
        backgroundColor: '#fff',
        borderRadius: 10,
        elevation: 5,
    },
    profileInfoTitle: {
        fontSize: 20,
        fontWeight: 'bold',
        marginBottom: 10,
        color: '#333',
    },
    profileInfoItem: {
        fontSize: 16,
        marginBottom: 5,
        color: '#555',
    },
    profileInfoLabel: {
        fontWeight: 'bold',
        color: '#333',
    },
    locationContainer: {
        padding: 20,
        margin: 10,
        backgroundColor: '#fff',
        borderRadius: 10,
        elevation: 5,
    },
    locationTitle: {
        fontSize: 20,
        fontWeight: 'bold',
        color: '#333',
    },
    configurationsContainer: {
        padding: 20,
        margin: 10,
        backgroundColor: '#fff',
        borderRadius: 10,
        elevation: 5,
    },
    configurationsTitle: {
        fontSize: 20,
        fontWeight: 'bold',
        marginBottom: 10,
        color: '#333',
    },
    configurationItem: {
        paddingVertical: 15,
        borderBottomWidth: 1,
        borderBottomColor: '#eee',
    },
    configurationItemText: {
        fontSize: 16,
        color: '#555',
    },
    quickLinksContainer: {
        padding: 20,
        margin: 10,
        backgroundColor: '#fff',
        borderRadius: 10,
        elevation: 5,
    },
    quickLinksTitle: {
        fontSize: 20,
        fontWeight: 'bold',
        marginBottom: 10,
        color: '#333',
    },
    quickLinkItem: {
        paddingVertical: 10,
        borderBottomWidth: 1,
        borderBottomColor: '#eee',
    },
    quickLinkItemText: {
        fontSize: 16,
        color: '#555',
    },
});