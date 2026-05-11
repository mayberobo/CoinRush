using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    public void GetBumped()
    {
      gameObject.transform.position = new Vector3(Random.Range(-4.7f, 4.7f), Random.Range(-4.6f, 4.6f), 0);
    }
}
