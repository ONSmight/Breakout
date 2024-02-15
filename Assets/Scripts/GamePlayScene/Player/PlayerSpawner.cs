using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Players;

    GameObject player;

    int p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameManager.GM.selectedPlayer;
        player = Instantiate(Players[p], transform.position, Quaternion.identity);
        player.transform.parent = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
