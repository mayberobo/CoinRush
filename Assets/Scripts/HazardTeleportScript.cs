using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardTeleportScript : MonoBehaviour
{

    public Transform t;
    public Transform startingPosition;
    
    
    public float speed = 5f;

    void Start()
    {
      startingPosition.position = new Vector3(Random.Range(-4.7f, 4.7f), Random.Range(-4.6f, 4.6f), 0);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
    }
}