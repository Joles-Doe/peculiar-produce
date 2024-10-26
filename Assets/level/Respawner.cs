using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public CameraControl cam;

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public GameObject player1;
    public GameObject player2;

    Vector3 spawnLocation;

    public void DestroyAndRespawn(GameObject _player)
    {
        print(_player == player1);
        if (_player == player1)
        {
            spawnLocation = player1.GetComponent<CheckpointHolder>().GetRespawnLocation();
            Destroy(player1);
            player1 = Instantiate(player1Prefab, spawnLocation, Quaternion.identity);
            player1.GetComponent<CheckpointHolder>().SetRespawnLocation(spawnLocation);
            player1.GetComponentInChildren<PlayerControl>().isPlayerOne = true;

            cam.player1 = player1.transform.GetChild(0).transform;
        }
        
        if (_player == player2)
        {
            spawnLocation = player2.GetComponent<CheckpointHolder>().GetRespawnLocation();
            Destroy(player2);
            player2 = Instantiate(player2Prefab, spawnLocation, Quaternion.identity);
            player2.GetComponent<CheckpointHolder>().SetRespawnLocation(spawnLocation);

            cam.player2 = player2.transform.GetChild(0).transform;
        }
    }
}
