using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TrainDepo : MonoBehaviour
{
    public Graph GlobalGraph;
    public GameObject TrainPrefab;


    /*
    void Launch(Vector2 start2d, Vector2 finish2d)
    {
        
        GameObject NewTrain = Instantiate(TrainPrefab, start2d, TrainPrefab.transform.rotation);
        Debug.Log("Train created");
        MoveTo(finish2d, NewTrain);

    }
    */
    public float speed;

    public Vector3 startCoord;
    public Vector3 endCoord;

    public int startId;
    public int endId;

    private GameObject NewTrain;
    Vector3 spawnPoint = new Vector3(100, 0);
    public AudioSource noise;

    void Start()
    {
        NewTrain = Instantiate(TrainPrefab, spawnPoint, TrainPrefab.transform.rotation);
        noise = NewTrain.GetComponent<AudioSource>();
        noise.enabled = false;
        NewTrain.GetComponent<Train>().GlobalGraph = GlobalGraph;
        NewTrain.GetComponent<Train>().depo = this;

    }


    /*
    public void MoveTo(Vector3 end_coord, GameObject movable)
    {
        Vector2 direction = (end_coord - movable.transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }
    */

    Vector2 direction;

    void Update()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {

            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                startCoord = rayHit.transform.position;
                startId = Convert.ToInt32(rayHit.transform.name);
            }


        }


        if (Input.GetMouseButtonUp(1))
        {

            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                endCoord = rayHit.transform.position;
                endId = Convert.ToInt32(rayHit.transform.name);
            }


        }

        /*
        if (Input.GetKeyUp(KeyCode.Return))
        {
            NewTrain.transform.position = startCoord;
            //NewTrain.transform.rotation = Quaternion.Euler(0, 0, 0);
            noise.enabled = true;
           
            

            NewTrain.GetComponent<Train>().AdvancedMove(startId, endId);


            if ((NewTrain.transform.position - endCoord).magnitude < 0.2f)
            {
                NewTrain.transform.position = spawnPoint;
                
                noise.enabled = false;
            }
        }
        */

        


        /*            
        if (Input.GetKeyUp(KeyCode.Return))
        {
            NewTrain.transform.position = startCoord;
            NewTrain.transform.rotation = Quaternion.Euler(0, 0, 0);
            noise.enabled = true;
            moveKey = true;
        }

        if (moveKey)
        {
            direction = (endCoord - NewTrain.transform.position).normalized;
            NewTrain.transform.Translate(direction * speed * Time.deltaTime);
        }

        if ((NewTrain.transform.position - endCoord).magnitude < 0.5f)
        {
            NewTrain.transform.position = spawnPoint;
            moveKey = false;
            noise.enabled = false;
        }
        */




    }
}
