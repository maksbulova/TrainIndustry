using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMine : BasicProduction
{
    public CoalMine(int id) : base(id) //чтоб вс не ныл
    {

    }


    public void Start()
    {
        Storage = new Dictionary<string, Resource>();
        local_input = new List<Resource>();
        local_output = new List<Resource>() { new Resource("coal", "granual", 2) };
        Produce_time = 10.0f;
        energyConsumtion = 8;


        

        LocalRecipe = new Recipe(local_input, local_output, Produce_time, energyConsumtion);
    }


}