using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    private GameObject liquid;
    private float injectingSpeed;

    public Liquid(GameObject liquid, float injectingSpeed) 
    {
        this.liquid = liquid;
    }
    
    public void Inject() 
    {
        Instantiate(liquid, transform.position, Quaternion.identity);
        liquid.AddComponent<Rigidbody2D>().velocity = new Vector2(injectingSpeed, 0);
    }
}
