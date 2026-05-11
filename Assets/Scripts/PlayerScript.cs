using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them
    
    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;

    //TextMeshPro is a component that draws text on the screen.
    //We use this one to show our score.
    public HazardTeleportScript hazard;
    public TextMeshPro ScoreText;

    public TextMeshPro HealthText;
    public Sprite normalFace;
    public Sprite attackedFace;
    
    //This will control how fast the player moves
    public float Speed = 5;
    
    //This is how many points we currently have
    public int Score = 0;

    public int Health = 3;
    
    //Start automatically gets triggered once when the objects turns on/the game starts
   // private GameObject Crusher;
    void Start()
    {
        UpdateScore();
        UpdateHealth();
        
    }

    private void takeAwayLife()
    {
        Health--;
        UpdateHealth();
        if (Health <= 0)
        {
            Debug.Log("No more lives xd");
            Die();
        }
    }

    private GameObject obj = GameObject.Find("Crusher");
    void Update()
    {
        
       
      
        if (Input.GetKey(KeyCode.LeftShift)) // sprint feature
        {
            Speed = 10;
        }
        else
        {
            Speed = 5;
        }
      //  Vector2 vel = new Vector2(0,RB.linearVelocity.y);
        Vector2 vel = new Vector2(0,0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed; // go right
        }
    
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed; // go left
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Speed; // go up
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -Speed; // go down
        }
        RB.linearVelocity = vel;
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        //If it does...
        if (other.gameObject.CompareTag("Hazard"))
        {
            takeAwayLife();
        }
        
        
        
        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        HazardTeleportScript haz = other.gameObject.GetComponent<HazardTeleportScript>();
        //If it does, run the code block belows

        
        if (coin != null)
        {
            coin.GetBumped(); 
         
            //Make your score variable go up by one. . .
            Score++;
            //And then update the game's score text
            UpdateScore();
        } 
     }

    //This function updates the game's score text to show how many points you have
    //Even if your 'score' variable goes up, if you don't update the text the player doesn't know
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
        if (Score == 10)
        {
            GameObject hazard = GameObject.Find("Hazard");

            if (hazard != null)
            {
                HazardTeleportScript hazardScript =
                    hazard.GetComponent<HazardTeleportScript>();

                if (hazardScript != null)
                {
                    hazardScript.enabled = true;
                }
            }
        }
        if (Score == 20)
        {
            GameObject crusher = GameObject.Find("CrusherSprite");
            if (crusher != null)
            {
                Crusher crusherScript = crusher.GetComponent<Crusher>();
                if (crusherScript != null)
                {
                    crusherScript.enabled = true;
                }
            }
        }
        
        if (Score == 30)
        {
            GameObject crusher = GameObject.Find("CrusherSpriteBelow");
            if (crusher != null)
            {
                CrusherBelow crusherScript = crusher.GetComponent<CrusherBelow>();
                if (crusherScript != null)
                {
                    crusherScript.enabled = true;
                }
            }
        }
    }

    public void UpdateHealth()
    {
        HealthText.text = "Health: " + Health;
    }

    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
}
