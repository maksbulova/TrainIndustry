using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : Vertex
{
    public Production(int id) : base(id)
    {
    }

    public static bool Check(Dictionary<string, Resource> Storage, Recipe recipe)
    {
        if(UIManager.energyLevel < recipe.EnergyConsumption)
        {
            return false;
        }

        if(recipe.InputRes == null)
        {
            //Debug.Log("запрос пуст, проверку прошли");
            return true;
        }
        //Debug.Log("запрос есть");

        foreach (Resource res in recipe.InputRes)
        {
            if (!Storage.ContainsKey(res.Name))
            {
                //Debug.Log("не прошла проверки, нет нужного ресурса");
                return false;
            }
            if (Storage[res.Name].Amount < res.Amount)
            {
                //Debug.Log("не прошла проверки, недостаточно ресурса");
                return false;
            }
        }
        //Debug.Log("запрос существует, проверку прошли");
        return true;
    }

}



public class Recipe
{
    public List<Resource> InputRes = new List<Resource>();
    public List<Resource> OutputRes = new List<Resource>();
    public float ProduceTime;
    public int EnergyConsumption;
    //public float WaterConsumption;

    public Recipe(List<Resource> inRes, List<Resource> outRes, float time, int energy)
    {
        InputRes = inRes;
        OutputRes = outRes;
        ProduceTime = time;
        EnergyConsumption = energy;
    }



}




public class Resource //всё перевозимое, как базовое сырье так и товары
{


    public string Name; //{ get; set; }
    public int Amount; //{ get; set; }
    public string Type; //{ get; set; }

    public Resource(string label, string type)
    {
        Name = label;
        Amount = 0;
        Type = type;
    }
    public Resource(string label, string type, int amount)
    {
        Name = label;
        Amount = amount;
        Type = type;
    }
    // два конструктора

}

