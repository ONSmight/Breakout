using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] Balls;

    GameObject ball;
    Transform trans;

    // Start is called before the first frame update
    void Start()
    {

        ball = Instantiate(Balls[Random.Range(0, 7)], new Vector2(transform.position.x, transform.position.y + (0.55f)), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
