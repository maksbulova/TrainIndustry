using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float Speed;


    public Graph GlobalGraph;
    public bool moveKey1 = true;
    public bool moveKey2 = true;
    float travelTime;

    public IEnumerator AdvancedMove(int start_vert, int end_vert)
    {
        LinkedList<Vertex> way = GlobalGraph.FindDeWay(start_vert, end_vert); // должно построить путь, пока не работает
        LinkedListNode<Vertex> node;

        if (way == null) Debug.Log("way is null");

        foreach (Vertex ver in way)
        {
            if (ver == null)
            {
                Debug.Log("одна из вершин null");
            }
            else
            {
                Debug.Log(ver.name);
            }
            
        }



        for (node = way.First; node != null; node = node.Next)
        {

            if (node.Next != null)
            {
                

                Debug.Log("промежуточный путь: " + node.Value.name + " => "+ node.Next.Value.name);

                StartCoroutine(Move(node.Value.coords, node.Next.Value.coords));
                travelTime = (node.Next.Value.coords - node.Value.coords).magnitude / Speed;
                yield return new WaitForSeconds(travelTime);


            }
        }
        /*
        if (node.Next == null)
        {
            for (node = way.Last; node != null; node = node.Previous)
            {
                if (node.Previous != null)
                {
                    StartCoroutine(Move(node, node.Previous));
                }
            }

        }
        */

    }
    /*
    public IEnumerator Move(LinkedListNode<Vertex> start_vert, LinkedListNode<Vertex> end_vert)
    {

        Debug.Log("едет");

        Vector3 end_coord = end_vert.Value.coords;
        Vector3 start_coord = end_vert.Value.coords;

        transform.position = start_coord;

        Vector2 direction = (end_coord - start_coord).normalized;

        while ((this.transform.position - end_coord).magnitude > 0.2f)
        {
            transform.Translate(direction * Speed * Time.deltaTime);
            yield return null;
        }

    }
    */
    public IEnumerator Move(Vector3 start_coord, Vector3 end_coord)
    {

        
        Debug.Log("едет");
        transform.position = start_coord;
        Vector3 direction = (end_coord - start_coord).normalized;
        //this.transform.rotation = Quaternion.LookRotation(direction);

        while ((end_coord - this.transform.position).magnitude > 0.2f)
        {
            transform.Translate(direction * Speed * Time.deltaTime);
            yield return null;
            
        }
        moveKey1 = false;

    }

    public TrainDepo depo;

    public float x, y, z;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StartCoroutine( AdvancedMove(depo.startId, depo.endId));
        }

       
        y++;
        //transform.localRotation = Quaternion.Euler(-90, y, 0);

        //transform.localEulerAngles = new Vector3(-90, , 0);
    }


    /*
    public List<Wagon> wagons;
    

    public void AddWagon(string newType)
    {
        this.wagons.Add(new Wagon(newType, wagons.Count));
    }
    public void DeleteWagon(int id)
    {
        this.wagons.RemoveAt(id);
    }
    */

}


/*
public class Wagon
{
    private readonly int Wagon_id;
    public string TypeWagon;
    public Dictionary<string, Resource> Cargo;


    public void ShowWagon()
    {
        foreach (KeyValuePair<string, Resource> keyValue in Cargo)
        {
            Debug.Log(keyValue.Value.Name + " в поезде столько " + keyValue.Value.Amount);
        }
    }


    public Wagon(string aType, int num)
    {
        Wagon_id = num;
        TypeWagon = aType; 
        Cargo = null;
    }

    public void Load(Dictionary<string, Resource> giver, Dictionary<string, Resource> taker, Resource res)
    {

        giver[res.Name].Amount -= res.Amount;
        taker[res.Name].Amount += res.Amount;        
    }
}
*/
