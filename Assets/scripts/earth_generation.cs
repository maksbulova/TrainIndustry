using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class earth_generation : MonoBehaviour
{
    public Transform[] earth_tiles;
    public user globalUser;
    private int map_size;
    private float sdvig_x = 1f;
    private float sdvig_y = 1f;
    public Transform earth;
    public float spawn_time;
    private int a = 0;
    public float FlightSpeed;
    private float distance;

    public IEnumerator fly(Transform Tile, Vector3 FinishPosition)
    {
        Tile.transform.position = FinishPosition + Vector3.down * 20;

        do
        {
            distance = (Tile.transform.position - FinishPosition).magnitude;
            FlightSpeed = Mathf.Sqrt(distance);
            Tile.transform.Translate(Vector3.up * FlightSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        } while (distance > 0.1f);


    }

    IEnumerator creat_earth()
    {

        for (int i = 0; i < map_size; i++)
        {
            for (int k = 0; k < map_size * 2; k++)
            {
                
                /*Transform newTile = */Instantiate(earth_tiles[Random.Range(0, earth_tiles.Length)], 
                    new Vector3(sdvig_x * k - map_size, sdvig_y * i + 0.5f * (k % 2) - map_size / 2, 2),
                    Quaternion.identity).transform.SetParent(earth);
                //StartCoroutine(fly());
                //yield return new WaitForSeconds(spawn_time); 
                yield return new WaitForFixedUpdate();
                

            }
        }
        /*
        for (int i = 0; i < map_size; i++)
        {
            for (int k = 0; k < map_size * 2; k++)
            {
                a++;
                Instantiate(earth_tiles[Random.Range(0, earth_tiles.Length)], new Vector3(sdvig_x * k - map_size, sdvig_y * i + 0.5f*(k%2) - map_size/2 - spown_swing, 2), Quaternion.identity).transform.SetParent(earth);
                //yield return new WaitForSeconds(spawn_time); 
                if (a >= 5)
                {
                    a = 0;
                    yield return new WaitForFixedUpdate();
                }
                
            }
        }
        */
    }
    

    void Start()
    {
        map_size = globalUser.MapSize;
        StartCoroutine(creat_earth());
        
    }

 

    void Update()
    {
        
    }
}
