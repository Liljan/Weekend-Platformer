using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private GameObject player;

    //public Transform[] checkPoints;
    public Transform startPoint;
    private Transform currentCheckpoint;

	// Use this for initialization
	void Start ()
    {
        // Register listeners
        PlayerEvents.Instance().DespawnPlayer += SpawnPlayer;
        LevelEvents.Instance().SetCheckpoint += SetCheckpoint;
        LevelEvents.Instance().ReachGoal += WinLevel;

        // Level Manager logic
        currentCheckpoint = startPoint;

        player = Instantiate(PlayerPrefab);
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player.transform.position = currentCheckpoint.position;
        player.transform.rotation = Quaternion.identity;
        PlayerEvents.Instance().InvokeSpawnPlayer(player.transform);
    }

    public void SetCheckpoint(Transform t)
    {
        currentCheckpoint = t;
    }

    private void WinLevel()
    {
        StartCoroutine(Win());
    }

    private IEnumerator Win()
    {
        Debug.Log("Level won!");
        yield return new WaitForSeconds(2.0f);
    }
}
