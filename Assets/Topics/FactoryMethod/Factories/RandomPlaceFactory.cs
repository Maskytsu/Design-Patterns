using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlaceFactory : MonoBehaviour, ICubeFactory
{
    [SerializeField] private GameObject _cubeAPrefab;
    [SerializeField] private GameObject _cubeBPrefab;
    [SerializeField] private GameObject _cubeCPrefab;

    private int _typeToInstantiate = 0;

    public ICube CreateCube()
    {
        GameObject instantiatedCube = null;
        Vector3 randomPosition = new Vector3(Random.Range(-16f, -2f), 0.5f, Random.Range(-8f, 8f));

        if (_typeToInstantiate == 0)
        {
            instantiatedCube = Instantiate(_cubeAPrefab, randomPosition, Quaternion.identity);
            _typeToInstantiate++;
        }
        else if(_typeToInstantiate == 1)
        {
            instantiatedCube = Instantiate(_cubeBPrefab, randomPosition, Quaternion.identity);
            _typeToInstantiate++;
        }
        else if (_typeToInstantiate == 2)
        {
            instantiatedCube = Instantiate(_cubeCPrefab, randomPosition, Quaternion.identity);
            _typeToInstantiate = 0;
        }

        if (instantiatedCube != null)
        {
            ICube cube = instantiatedCube.GetComponent<ICube>();
            cube.SayHi();
            return cube;
        }
        else
        {
            Debug.LogError("Type index out of range.");
            return null;
        }
    }
}
