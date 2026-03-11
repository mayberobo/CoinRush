using UnityEngine;

public class ColorChangerController : MonoBehaviour
{
    //This is about as simple a script as you can imagine
    //It makes it so that if you hit the space bar, the attached sprite changes colors
    
    //This is the SpriteRenderer component in charge of drawing this object's sprite
    public SpriteRenderer SR;
    public Transform T;
    
    //This is the color we want the object to turn
   // public Color TargetColor = Color.red;
    
    //Any code inside of Update's {} brackets runs once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            T.position -= new Vector3(3 * Time.deltaTime, 0, 0);
            SR.color = Color.red;
           
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SR.color = Color.blue;
            T.position += new Vector3(3 * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SR.color = Color.yellow;
            T.position += new Vector3(0, 3 * Time.deltaTime, 0);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SR.color = Color.green;
            T.position -= new Vector3(0, 3 * Time.deltaTime, 0);
        }
        
        
        
        
        
      
    }
}
