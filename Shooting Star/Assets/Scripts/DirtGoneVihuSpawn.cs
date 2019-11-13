using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtGoneVihuSpawn : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject player;
    private GameObject[] dirts;

    private bool dirtsRemaining = true;
    private Vector3 nextToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        dirts = GameObject.FindGameObjectsWithTag("Dirt");
    }


    // Checks if player destroys all dirts, and then spawns boss next to player
    void Update()
    {
        if (dirtsRemaining)
        {
            if (GameObject.FindGameObjectsWithTag("Dirt").Length == 0)
            {
                Debug.Log("All dirts destroyed");
                dirtsRemaining = false;
                nextToPlayer = player.transform.position + new Vector3(5, 5, 0);
                Instantiate(bossPrefab, nextToPlayer, player.transform.rotation);
            }
        }
    }
}
