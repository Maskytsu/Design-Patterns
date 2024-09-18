using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    private RandomPlaceFactory _randomPlaceFactory;
    private RandomTypeFactory _randomTypeFactory;
    //V could be a dict to easly search for specific cubes, but then they would need to be signed
    private List<ICube> _cubes = new List<ICube>();
    private void Awake()
    {
        _randomPlaceFactory = GetComponent<RandomPlaceFactory>();
        _randomTypeFactory = GetComponent<RandomTypeFactory>();
    }
    void Start()
    {
        StartCoroutine(CreateCubes());
    }

    IEnumerator CreateCubes()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(3f);
            _cubes.Add(_randomPlaceFactory.CreateCube());
            _cubes.Add(_randomTypeFactory.CreateCube());
        }

        foreach (ICube cube in _cubes)
        {
            yield return new WaitForSeconds(1.5f);
            cube.StartRotation();
        }
    }
}
