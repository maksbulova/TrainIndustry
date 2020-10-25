using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseBuilder : MonoBehaviour
{
    public Graph GlobalGraph;
    [Space]
    public BasicProduction[] Prefabs;
    Vector2 rnd_vect;
    bool bkey;

    public void RandomSpawn()
    {
        
        do
        {
            bkey = false;
            rnd_vect = new Vector2(Random.Range(-20.0f, 20.0f), Random.Range(-10.0f, 10.0f)); // вставь размер карты

            foreach (Vertex ver in GlobalGraph.vertices)
            {
                if (ver == null)
                {
                    
                }
                else if ((rnd_vect - ver.coords).magnitude < 5.0f)
                {
                    bkey = true;
                }
            }

            
        } while (bkey);
        


        BasicProduction newFactory = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], rnd_vect, Quaternion.identity);
        
        
        newFactory.vert_id = GlobalGraph.numVerts; 
        newFactory.coords = newFactory.transform.position;
        newFactory.name = newFactory.vert_id.ToString();

        GlobalGraph.AddVertex(GlobalGraph.numVerts, newFactory);





        //GlobalGraph.Show_matrix();
    }

    public void RandomSpawn(int i)
    {

        Vector2 rnd_vect = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-20.0f, 20.0f));
        BasicProduction newFactory = Instantiate(Prefabs[i], rnd_vect, Quaternion.identity);


        newFactory.vert_id = GlobalGraph.numVerts; 
        newFactory.coords = newFactory.transform.position;
        newFactory.name = newFactory.vert_id.ToString();

        GlobalGraph.AddVertex(GlobalGraph.numVerts, newFactory);
    }




    public float targetTime = 5.0f;
    private float currentTime = 0.0f;
    public float balanser = 1.5f;

    private void Start()
    {
        RandomSpawn(0); // стартовый завод чтоб не в ноль по энергии

        
    }

    void Update()
    {

        currentTime += Time.deltaTime;

        if (currentTime >= targetTime )
        {
            RandomSpawn();
            currentTime = 0.0f;
            targetTime *= balanser;
        }

        
    }
}
