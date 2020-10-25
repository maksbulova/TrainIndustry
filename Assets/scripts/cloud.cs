using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private bool key_raise;

    public Sprite clear, dark;
    public ParticleSystem rain;

    

    private void Start()
    {
        rain.Stop();
        StartCoroutine(rndDelay());
        
        
    }
    
    private float swing = 0;

    public IEnumerator fly()
    {
        while (Application.isPlaying)
        {
            transform.Translate(new Vector3(-0.5f, swing) * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
    }

    public IEnumerator swing_time()
    {
        while (Application.isPlaying)
        {
            if (swing > 1)
            {
                key_raise = false;
            }
            else if (swing < -1)
            {
                key_raise = true;
            }

            if (key_raise)
            {
                swing = swing + 0.1f;
            }
            else if (!key_raise)
            {
                swing = swing - 0.1f;
            }

            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public IEnumerator rndDelay()
    {
        yield return new WaitForSeconds(Random.Range(0, 5.0f));
        StartCoroutine(fly());
        StartCoroutine(swing_time());
        StartCoroutine(bad_weather());

    }


    public IEnumerator bad_weather()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
            this.GetComponent<SpriteRenderer>().sprite = dark;
            rain.Play();

            yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
            this.GetComponent<SpriteRenderer>().sprite = clear;
            rain.Stop();
        }
        

    }

}