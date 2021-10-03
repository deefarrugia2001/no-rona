using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Germ Config")]
public class GermConfig : ScriptableObject
{
    [SerializeField] GameObject germPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] sbyte germCount;
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] float movementSpeed;

    public GameObject Germ => germPrefab;

    public List<Transform> Waypoints 
    {
        get 
        {
            List<Transform> waypoints = new List<Transform>();
            foreach(Transform child in pathPrefab.transform)
                waypoints.Add(child);
            return waypoints;
        }
    }

    public sbyte GermCount => germCount;
    public float SecondsBetweenSpawns => secondsBetweenSpawns;
    public float MovementSpeed => movementSpeed;
}