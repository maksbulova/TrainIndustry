using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStation : BasicProduction
{
    public PowerStation(int id) : base(id) //чтоб вс не ныл
    {

    }


    public void Start()
    {
        Storage = new Dictionary<string, Resource>();
        local_input = new List<Resource>() { /*new Resource("coal", "granual", 1)*/ };
        local_output = new List<Resource>() { new Resource("energy", "special", 20) };
        Produce_time = 5.0f;
        energyConsumtion = 0;

        LocalRecipe = new Recipe(local_input, local_output, Produce_time, energyConsumtion);
    }

}
