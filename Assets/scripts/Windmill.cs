using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : BasicProduction
{
    public Windmill(int id) : base(id) //чтоб вс не ныл
    {

    }


    public void Start()
    {
        Storage = new Dictionary<string, Resource>();
        local_input = new List<Resource>() { new Resource("corn", "granual", 3) };
        local_output = new List<Resource>() { new Resource("bread", "solid", 1) };
        Produce_time = 8.0f;
        energyConsumtion = 0;

        LocalRecipe = new Recipe(local_input, local_output, Produce_time, energyConsumtion);
    }


}