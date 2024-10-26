using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public void ChangeCheckpoint(Transform _newCheckpoint, Transform _player)
    {
        if (_player.CompareTag("Player") == true)
        {
            Vector3 checkpoint = _newCheckpoint.position;
            checkpoint.y += 25;

            if (_player.GetComponent<CheckpointHolder>().GetRespawnLocation() != checkpoint)
            {
                _player.GetComponent<CheckpointHolder>().ChangeRespawnLocation(checkpoint);
            }
        }
    }
}
