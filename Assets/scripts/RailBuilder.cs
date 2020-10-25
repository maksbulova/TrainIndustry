using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;



public class RailBuilder : MonoBehaviour
{
    public GameObject RailLinePrefab;

    


    public Graph GlobalGraph;



    private void Start()
    {
        //GlobalGraph.AddEdge
    }





    void BuildRailLine(Vector2 start2d, Vector2 finish2d)
    {
        if (UIManager.energyLevel < (int)(finish2d - start2d).magnitude) return;
        
        GameObject NewRailLine = Instantiate(RailLinePrefab);
        LineRenderer RailRenderer = NewRailLine.GetComponent<LineRenderer>();

        Vector3 start3d = new Vector3(start2d.x, start2d.y, 1);
        Vector3 finish3d = new Vector3(finish2d.x, finish2d.y, 1);

        RailRenderer.SetPosition(0, start3d);
        RailRenderer.SetPosition(1, finish3d);

        GlobalGraph.AddEdge(Convert.ToInt32(OneId), Convert.ToInt32(AnotherId));


        UIManager.energyLevel -= (int) (finish2d - start2d).magnitude;


    }

    private Vector2 OneSide;
    private Vector2 AnotheSide;
    private string OneId;
    private string AnotherId;

        




    private void Update()
    {










        // В данном случае мы преобразуем нашу позицию мышки на 
        //экране в точку на мировом пространстве относительно камеры

        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Анализировать будем только при нажатии мышки

        if (Input.GetMouseButtonUp(0))
        {

            /*Для работы Raycast необходимо, чтоб объект имел компонент Collider
            В rayHit мы занесем результат выполнения команды Raycast
            там будет либо null, если raycast никого не задел, либо первый
            объект, стоящий на пути мышки (какой объект будет первым
            решает его положение Z в мировом пространстве)*/

            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                //Debug.Log("0 click: " + rayHit.transform.name);
                OneSide = rayHit.transform.position;
                OneId = rayHit.transform.name;
            }
                
                
        }


        if (Input.GetMouseButtonUp(1))
        {

            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                //Debug.Log("1 click: " + rayHit.transform.name);
                AnotheSide = rayHit.transform.position;
                AnotherId = rayHit.transform.name;
            }


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuildRailLine(OneSide, AnotheSide);
        }


    }



}
