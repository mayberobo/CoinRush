using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class CrusherBelow : MonoBehaviour
{

    public Transform T;
    public float timer;
    public Transform player;

    public Rigidbody2D bodyThing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        T.position = new Vector3(0, -6.13f);
        timer = 0;
        gameObject.tag = "Celing";
    }

    private void OnEnable()
    {
        Start();
    }

    IEnumerator crushDown()
    {
        gameObject.tag = "Hazard";
        // Debug.Log("cooked im going down now xd");
        Vector3 targetToGoTo = T.position + new Vector3(0, 50, 0);
        T.position = Vector3.MoveTowards(T.position, targetToGoTo, 7f * Time.deltaTime);
        yield return new WaitForSeconds(2.5f);
        this.enabled = false;
        yield return new WaitForSeconds(5);
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 4)
        {
            StartCoroutine(crushDown());
        }
        else
        {
            timer += Time.deltaTime;
            T.position = new Vector3(player.position.x, -6.13f);
        }

       
    }
}