using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weather : MonoBehaviour
{
    public cloud[] cloudsPrefabs;
    [Space]
    public user GlobalUser;
    public Transform sky;

    void Start()
    {

        
        for (int k = 0; k < GlobalUser.MapSize/3; k++)
        {
            Instantiate(cloudsPrefabs[Random.Range(0, cloudsPrefabs.Length)], new Vector3(Random.Range(-GlobalUser.MapSize, GlobalUser.MapSize), Random.Range(-GlobalUser.MapSize/2, GlobalUser.MapSize/2), - 2), Quaternion.identity).transform.SetParent(sky);
        }
        
    }

    

    void Update()
    {
        
    }
}
   


