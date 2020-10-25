using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMine : BasicProduction
{
    public SandMine(int id) : base(id) //чтоб вс не ныл
    {

    }


    public void Start()
    {
        Storage = new Dictionary<string, Resource>();
        local_input = new List<Resource>();
        local_output = new List<Resource>() { new Resource("sand", "granual", 1) };
        Produce_time = 6.0f;
        energyConsumtion = 4;

        LocalRecipe = new Recipe(local_input, local_output, Produce_time, energyConsumtion);
    }

}
