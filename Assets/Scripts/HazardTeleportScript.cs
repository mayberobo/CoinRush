using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardTeleportScript : MonoBehaviour
{

    public Transform t;
    public void teleportHazard()
    {
        //This teleports the hazard
        t.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 4.6f), 0);
    }
}