using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    [SerializeField] GameObject liquid; //Liquid represents the projectile to emerge from the syringe in order to destroy the germs.
    Liquid liquidObject;
    float injectingSpeed = 20f;

    [SerializeField] float movementSpeed = 10f;

    Coroutine injectCoroutine;
    float injectingTime = .3f;

    float xMin, xMax;
    float padding = 1f;

    void Start()
    {
        liquid = Resources.Load<GameObject>("Prefabs/Liquid"); //Instead of loading the prefab via the Inspector, it will be loaded amidst runtime from Resources/Prefabs whereby Liquid.prefab will be fetched.
        CheckBoundaries();
    }

    void Update()
    {
        Move();
        Inject();
    }

    void Move() 
    {
        float horizontalAxis = Input.GetAxis("Horizontal"); //Return the horizontal axis as set in Input Settings.
        Vector2 movement = Vector2.right * horizontalAxis; //Fetch horizontal movement only.
        transform.Translate(movementSpeed * Time.deltaTime * movement); //Move the syringe horizontally at a frame-independent rate.

        Vector3 boundaryMovement = transform.position; //Fetch the current position of the syringe.
        float clampedHorizontalMovement = Mathf.Clamp(boundaryMovement.x, xMin, xMax); //Limit the horizontal movement of the syringe to the xMin and xMax values set in CheckBoundaries (invoked in the built-in Start()).
        boundaryMovement = new Vector3(clampedHorizontalMovement, transform.position.y, transform.position.z); //Leave the y and z positions intact.
        transform.position = boundaryMovement; //Update the current position with the clamped horizontal movement.
    }

    void CheckBoundaries() 
    {
        Camera camera = Camera.main; //Fetch the main camera.
        xMin = camera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = camera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }

    void Inject() 
    {
        if(Input.GetButtonDown("Fire1")) //If the button is held down, inject continuously until the button is released.
            injectCoroutine = StartCoroutine(InjectContinuously());
        if (Input.GetButtonUp("Fire1")) //When the button is released, stop injecting.
            StopCoroutine(injectCoroutine);
    }

    IEnumerator InjectContinuously() 
    {
        liquidObject = new Liquid(liquid, injectingSpeed);
        liquidObject.Inject();
        yield return new WaitForSeconds(injectingTime);
    }
}