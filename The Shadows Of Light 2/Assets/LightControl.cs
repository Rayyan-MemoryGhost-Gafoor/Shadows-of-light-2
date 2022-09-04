using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    [Header("light Scene Settings")]
    public float start_color_temp;
    public float end_color_temp;
    public Color start_color, end_color;
    public float duration;
    [Header("References")]
    public GameObject light_gameobject;
    Light directional_light;

    /*public Color light_color;
    [Range(1500, 20000)]
    public float colourTemp;
    */

    // Start is called before the first frame update
    void Start()
    {
        directional_light = light_gameobject.GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.T))
        {
            directional_light.colorTemperature = colourTemp;
            directional_light.color = light_color;

        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("LC-Player Has Exited");
            StartCoroutine(lerp_float(directional_light.colorTemperature, start_color_temp, end_color_temp,duration));
            StartCoroutine(lerp_colour(directional_light.color, start_color, end_color, duration));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(lerp_float(directional_light.colorTemperature, end_color_temp, start_color_temp,  duration));
            StartCoroutine(lerp_colour(directional_light.color, end_color, start_color,  duration));
        }
    }
    IEnumerator lerp_float(float lerped_value,float start, float end, float duration)
    {
        Debug.Log("LC- Lerp Float function" + " called");
        float time_elapsed=0;
        while (time_elapsed < duration)
        {
            lerped_value = Mathf.Lerp(start, end, time_elapsed / duration);
            
            time_elapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("LC- Lerp Float function" + " ended");
        lerped_value = end;
    }
    IEnumerator lerp_colour(Color lerped_colour, Color start, Color end, float duration)
    {
        float time_elapsed = 0;
        while (time_elapsed < duration)
        {
            lerped_colour = Color.Lerp(start, end, time_elapsed / duration);
            
            time_elapsed += Time.deltaTime;
            yield return null;
        }
        lerped_colour = end;
    }
}