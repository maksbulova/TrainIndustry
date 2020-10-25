using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
public class Vertex
{
    public bool wasVisited;// The only method we need for the class is a constructor method that allows
                           // us to set the label and wasVisited data members
    public string label;
    public Vertex(string label)
    {
        this.label = label; //name vertex
        wasVisited = false;
    }
}
*/

public class Vertex : MonoBehaviour
{
    [HideInInspector]
    public Vector2 coords;
    [HideInInspector]
    public bool wasVisited;
    public int vert_id;
    public Vertex(int id) 
    {
        
        vert_id = id;
        wasVisited = false;
    }
}

public class Graph : MonoBehaviour
{


    
    private const int NUM_VERTICES = 20;
    public Vertex[] vertices;
    private int[,] AdjMatrix; // матрица смежности
    [HideInInspector]
    public int numVerts;

    public Graph()
    {
        vertices = new Vertex[NUM_VERTICES];
        AdjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;
        for (int j = 0; j < NUM_VERTICES; j++)
            for (int k = 0; k < NUM_VERTICES - 1; k++)
                AdjMatrix[j, k] = 0;
    }

    

    public void AddVertex(int id, Vertex ver)
    {
        vertices[numVerts] = ver;
        numVerts++;
        //Debug.Log(numVerts + " баз на сцене");
    }


    public void AddEdge(int start, int eend)
    {
        AdjMatrix[start, eend] = 1;
        AdjMatrix[eend, start] = 1;
    }



    public void Show_matrix()
    {
        for (int j = 0; j < numVerts; j++)
        {
            for (int k = 0; k < numVerts; k++)
            {
                if (k != numVerts - 1)
                {
                    Debug.Log(AdjMatrix[j, k] + " ");
                }
                else
                {
                    Debug.Log(AdjMatrix[j, k] + " строка");
                }
            }
        }

    }
    public void ShowVertex(int v)
    {
        Debug.Log(vertices[v].vert_id + " ");
    }

    public int NoSuccessors()
    {
        bool isEdge;

        for (int row = 0; row <= numVerts - 1; row++)
        {
            isEdge = false;
            for (int col = 0; col <= numVerts - 1; col++)
                if (AdjMatrix[row, col] > 0)
                {
                    isEdge = true;
                    break;
                }
            if (!(isEdge))
                return row;
        }

        return -1;
    }

    public void DelVertex(int vert)
    {
        if (vert != numVerts - 1)
        {
            for (int j = vert; j <= numVerts - 1; j++)
                vertices[j] = vertices[j + 1];
            for (int row = vert; row <= numVerts - 1; row++)
                MoveRow(row, numVerts);
            for (int col = vert; col <= numVerts - 1; col++)
                MoveCol(col, numVerts - 1);
        }
    }
    private void MoveRow(int row, int length)
    {
        for (int col = 0; col <= length - 1; col++)
            AdjMatrix[row, col] = AdjMatrix[row + 1, col];
    }
    private void MoveCol(int col, int length)
    {
        for (int row = 0; row <= length - 1; row++)
            AdjMatrix[row, col] = AdjMatrix[row, col + 1];
    }



    private int GetAdjUnvisitedVertex(int v, int verFinish)
    {
        for (int j = 0; j <= numVerts+1; j++)
            if ((AdjMatrix[v, j] == 1) && (!vertices[j].wasVisited))
                return j;
        return -1;
    }


    public LinkedList<Vertex> FindDeWay(int verStart, int verFinish)
    {
        LinkedList<Vertex> way = new LinkedList<Vertex>();
        Stack<int> gStack = new Stack<int>();
        vertices[verStart].wasVisited = true;
        gStack.Push(verStart);
        int currVertex, ver;
        while (gStack.Count > 0)
        {
            currVertex = gStack.Peek();
            ver = this.GetAdjUnvisitedVertex(currVertex, verFinish);
            if (ver == -1)
                gStack.Pop();
            else
            {
                way.AddLast(vertices[currVertex]);
                vertices[ver].wasVisited = true;
                gStack.Push(ver);
                ShowVertex(currVertex);
                ShowVertex(ver);
                Debug.Log(" ");
            }
        }
        for (int j = verStart; j <= verFinish +1; j++)
            vertices[j].wasVisited = false;

        foreach (Vertex v in way)
        {
            Debug.Log(v + "d");
        }

        return way;
    }
    /*
    public Stack<int> FindDeWay(int verStart, int verFinish)
    {

        Stack<int> gStack = new Stack<int>();
        vertices[verStart].wasVisited = true;
        gStack.Push(verStart);
        int currVertex, ver;
        while (gStack.Count > 0)
        {
            currVertex = gStack.Peek();
            ver = this.GetAdjUnvisitedVertex(currVertex, verFinish);
            if (ver == -1)
                gStack.Pop();
            else
            {

                vertices[ver].wasVisited = true;
                gStack.Push(ver);
                ShowVertex(currVertex);
                ShowVertex(ver);
                Debug.Log(" ");
            }
        }
        for (int j = verStart; j <= verFinish - 1; j++)
            vertices[j].wasVisited = false;

        foreach (int i in gStack)
        {
            Debug.Log(i + "w");
        }

        return gStack;
    }
    */


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("<color=red> _______________________ </color>");
            this.Show_matrix();
        }
    }

    void Start()
    {

        Graph theGraph = new Graph();

        //Graph theGraph = new Graph();
        /*
        theGraph.AddVertex(0);
        theGraph.AddVertex(1);
        theGraph.AddVertex(2);
        theGraph.AddVertex(3);
        theGraph.AddVertex(4);
        theGraph.AddVertex(5);
        theGraph.AddEdge(0, 1);
        theGraph.AddEdge(1, 2);
        theGraph.AddEdge(1, 5);
        theGraph.AddEdge(2, 3);
        theGraph.AddEdge(2, 4);

        theGraph.Show_matrix();
        
        for (int i = 0; i < 6; i++)
        {
            theGraph.ShowVertex(i);
        }
        

        Debug.Log("/n");

        theGraph.Show_matrix();

        Debug.Log("Finished.");
        */
    }


}






