using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) 
    {
        Destroy(collision.gameObject);
    }
}