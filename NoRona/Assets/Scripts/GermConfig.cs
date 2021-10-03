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
}