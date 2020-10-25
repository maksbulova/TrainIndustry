using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Farm : BasicProduction
{
    public Farm(int id) : base(id) //чтоб вс не ныл
    {

    }





    public void Start()
    {
        Storage = new Dictionary<string, Resource>();
        local_input = new List<Resource>();
        local_output = new List<Resource>() { new Resource("corn", "granual", 1) };
        Produce_time = 5.0f;
        energyConsumtion = 1;

        LocalRecipe = new Recipe(local_input, local_output, Produce_time, energyConsumtion);
    }

    
}
