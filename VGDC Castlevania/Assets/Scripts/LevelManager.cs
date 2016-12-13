using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentSpawn;

    private PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        //player.transform.position = currentSpawn.transform.position;
        player.Death();
    }
}
