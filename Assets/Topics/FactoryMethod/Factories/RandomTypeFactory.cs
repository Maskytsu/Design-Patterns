using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTypeFactory : MonoBehaviour, ICubeFactory
{
    [SerializeField] private GameObject _cubeAPrefab;
    [SerializeField] private GameObject _cubeBPrefab;
    [SerializeField] private GameObject _cubeCPrefab;

    private Vector3 _positionToInstantiate = new Vector3 (9f, 0.5f, -8f);
    private int _countCubes = 0;

    public ICube CreateCube()
    {
        GameObject instantiatedCube = null;

        int randomCube = Random.Range(0, 3);

        if (randomCube == 0)
        {
            instantiatedCube = Instantiate(_cubeAPrefab, _positionToInstantiate, Quaternion.identity);
        }
        else if (randomCube == 1)
        {
            instantiatedCube = Instantiate(_cubeBPrefab, _positionToInstantiate, Quaternion.identity);
        }
        else if (randomCube == 2)
        {
            instantiatedCube = Instantiate(_cubeCPrefab, _positionToInstantiate, Quaternion.identity);
        }

        _positionToInstantiate += new Vector3(0f, 0f, 2f);
        _countCubes++;

        if (instantiatedCube != null)
        {
            ICube cube = instantiatedCube.GetComponent<ICube>();
            if (_countCubes % 2 == 0) cube.SayHello();
            return cube;
        }
        else
        {
            Debug.LogError("Type index out of range.");
            return null;
        }
    }
}
