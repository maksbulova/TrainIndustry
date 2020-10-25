using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicProduction : Production // производитель базового сырья, наследует от графа добавление и т д
{

    //список хранимых на конкретном заводе ресурсов
    



    public Recipe LocalRecipe;
    public List<Resource> local_input;
    public List<Resource> local_output;
    public float Produce_time;
    public int energyConsumtion;

    

    public BasicProduction(int id) : base(id) //чтоб вс не ныл
    {
    }

    
    public Text recipeTime;
    

    private void Start()
    {
        
        recipeTime.text = LocalRecipe.ProduceTime + "с";

    }

    public void ShowStorage()
    {
        foreach (KeyValuePair<string, Resource> keyValue in Storage)
        {
            Debug.Log(keyValue.Value.Name + " на заводе" + this.vert_id + " столько " + keyValue.Value.Amount);
        }
    }




    public void Coord_OnClick()
    {
        
        
    }

    public int Id_OnClick()
    {
        return this.vert_id;
    }




    public void AddRes(string NewRes, string type)
    {
        Storage.Add(NewRes, new Resource(NewRes, type));
    }
    // добавление в словарь ресурса через конструктор

    public void IncreaseRes(string AddebleRes, int Added)
    {
        Storage[AddebleRes].Amount += Added;
    }



    

    public void Produce(Dictionary<string, Resource> Storage, Recipe Recipe)
    {
        UIManager.energyLevel -= Recipe.EnergyConsumption;

        if (Recipe.InputRes != null)
        {
            foreach (Resource res in Recipe.InputRes)
            {
                Storage[res.Name].Amount -= res.Amount;
            }
        }
        
        if(Recipe.OutputRes != null)
        {
            foreach (Resource res in Recipe.OutputRes)
            {
                if (!Storage.ContainsKey(res.Name))
                {
                    AddRes(res.Name, res.Type);
                }
                Storage[res.Name].Amount += res.Amount;

            }
        }
        //Debug.Log(this.vert_id + " что-то произвел, например " + this.Storage[LocalRecipe.OutputRes[0].Name]);

    }



    public Dictionary<string, Resource> Storage;
    

    public float currentTime = 0.0f;

    private void Update()
    {


        currentTime -= Time.deltaTime;

        if (currentTime <= 0.0f)
        {
            if (Check(this.Storage, this.LocalRecipe))
            {
                Produce(this.Storage, this.LocalRecipe);
                currentTime = this.LocalRecipe.ProduceTime;
            }
        }



        if (Input.GetKeyDown(KeyCode.I))
        {
            this.ShowStorage();
        }




        if (Storage.ContainsKey("energy") && Storage["energy"].Amount != 0)
        {
            UIManager.energyLevel += Storage["energy"].Amount;
            Storage["energy"].Amount = 0;
        }
    }


}