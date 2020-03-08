using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
 
public class NetworkManager : MonoBehaviour {
    public GameObject PlayerPrefab, SpawnPoint;
     
    void Start () {
        // On se connect directement au cloud de PUN, si vous avez sélectionné auto join dans la configuration
        // On devrait donc se connecter directement au Lobby
        PhotonNetwork.ConnectUsingSettings("tutopun");
    }
 
    // Après le Start() on rejoint le Lobby, c'est à dire qu'on est connecté au cloud de PUN
    // Maintenant il faut rejoindre une Room
    void OnJoinedLobby()
    {
        // On va créer une room pour 4 personnes maximun
        RoomOptions MyRoomOptions = new RoomOptions();
        MyRoomOptions.MaxPlayers = 4;
 
        // Ici on set de manière aléatoire le nom de l'utilisateur pour aller plus vite
        PhotonNetwork.playerName = "Player" + Random.Range(1, 500);
 
        // Enfin on rejoint la room demandé, du nom de "The Game" mais on pourrait mettre un nom différent
        // afin de créer une autre room
        PhotonNetwork.JoinOrCreateRoom("The Game", MyRoomOptions, TypedLobby.Default);
    }
 
    // Quand on a effectivement rejoint la room
    void OnJoinedRoom()
    {
        // On instancie le joueur à tout le réseau
        // Nom du prefab à instancier / Position / Rotation / Groupe
        // Le groupe permet de différencier des joueurs, ou d'autre éléments, que vous vouliez différencier rapidement
        // les joueurs des adversaires OU différencier les équipes des joueurs
        PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPoint.transform.position, Quaternion.identity, 0);
    }
}