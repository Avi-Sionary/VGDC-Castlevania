using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()    {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentSpawn = gameObject;
            Debug.Log("Activated a new checkpoint!");
        }
    }
}
