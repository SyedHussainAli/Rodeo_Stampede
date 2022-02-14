using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int positionZ = 14;
    private int positionX=4;
    public GameObject animal;
    public int animalRange;
    void Start()
    {
        for (int i = 0; i < animalRange; i++)
        {
            Vector3 position = new Vector3(Random.Range(-positionX, positionX), 0.6f, positionZ);
            Instantiate(animal, position, animal.transform.rotation);
            positionZ += 14;
        }
        
    }

}
