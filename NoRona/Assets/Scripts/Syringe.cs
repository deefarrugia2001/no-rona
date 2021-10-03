using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    [SerializeField] GameObject liquid; //Liquid represents the projectile to emerge from the syringe in order to destroy the germs.

    void Start()
    {
        liquid = Resources.Load<GameObject>("Prefabs/Liquid"); //Instead of loading the prefab via the Inspector, it will be loaded amidst runtime from Resources/Prefabs whereby Liquid.prefab will be fetched.
    }

    void Update()
    {
    }
}