using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MapChange : MonoBehaviour
{
    // public int currentlayer;
    // public int maxlayer;
    // public int playerlayer;
    // // private InputAction layerfront;
    // private InputAction layerback;
    // private InputAction changeplayerlayerfront;
    // private InputAction changeplayerlayerback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // maxlayer = 0;
        // bool layerexist = true;
        // while(layerexist == true)
        // {
        //     if(GameObject.Find("Map/"+maxlayer) != null)
        //     {
        //         maxlayer++;
        //     }
        //     else
        //     {
        //         layerexist = false;
        //     }
        // }
        // maxlayer--;
        // playerlayer = 0;
        // ChangeLayer(false, 0);
        // layerfront = InputSystem.actions.FindAction("LayerFront");
        // layerback = InputSystem.actions.FindAction("LayerBack");
        // changeplayerlayerfront = InputSystem.actions.FindAction("ChangePlayerLayerFront");
        // changeplayerlayerback = InputSystem.actions.FindAction("ChangePlayerLayerBack");
    }

    // Update is called once per frame
    void Update()
    {
        // if(layerfront.IsPressed())
        // {
        //     ChangeLayer(true,1);
        // }
        // if(layerback.IsPressed())
        // {
        //     ChangeLayer(true,-1);
        // }
        // if(changeplayerlayerfront.IsPressed())
        // {
        //     playerlayer++;
        //     ChangeLayer(true,0);
        // }
        // if(changeplayerlayerback.IsPressed())
        // {
        //     playerlayer--;
        //     ChangeLayer(true,0);
        //}
    }
    void init()
    {
        
    }
    // void ChangeLayer(bool add, int value)
    // {
    //     GameObject layer;
    //     layer = GameObject.Find("Map/"+currentlayer);
    //     layer.GetComponent<Collider2D>().enabled = false;
    //     if(add == true)
    //     {
    //         currentlayer += value;
    //     }
    //     if(add == false)
    //     {
    //         currentlayer = value;
    //     }
    //     while(currentlayer < 0 || currentlayer > maxlayer)
    //     {
    //         if(currentlayer > maxlayer)
    //         {
    //             currentlayer = 0 + currentlayer - maxlayer;
    //         }
    //         if(currentlayer < 0)
    //         {
    //             currentlayer = maxlayer + currentlayer;
    //         }
    //     }
    //     layer = GameObject.Find("Map/"+currentlayer + playerlayer);
    //     layer.GetComponent<Collider2D>().enabled = true;
    //     for(int i = 0; i < maxlayer; i++)
    //     {
    //         layer = GameObject.Find("Map/"+i);
    //         if(currentlayer - i >= 0 & currentlayer - i <= 3 )
    //         {
    //             float brightness = 1-(i/0.2f);
    //             layer.GetComponent<Renderer>().enabled = true;
    //             layer.GetComponent<Tilemap>().color = new Color(brightness,brightness,brightness,1);
    //         }
    //         else
    //         {
    //             layer.GetComponent<Renderer>().enabled = false;
    //         }
    //     }
    // }
}
