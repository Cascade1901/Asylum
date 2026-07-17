using UnityEngine;
using UnityEngine.Tilemaps;

public class MapChange : MonoBehaviour
{
    public int CurrentLayer;
    public int MaxLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxLayer = 0;
        bool LayerExist = true;
        while(LayerExist == true)
        {
            if(GameObject.Find("Map/"+MaxLayer) != null)
            {
                MaxLayer++;
            }
            else
            {
                LayerExist = false;
            }
        }
        MaxLayer--;
        ChangeLayer(false, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void init()
    {
        
    }
    void ChangeLayer(bool add, int value)
    {
        GameObject Layer;
        Layer = GameObject.Find("Map/"+CurrentLayer);
        Layer.GetComponent<Collider2D>().enabled = false;
        if(add == true)
        {
            CurrentLayer += value;
        }
        if(add == false)
        {
            CurrentLayer = value;
        }
        while(CurrentLayer < 0 || CurrentLayer > MaxLayer)
        {
            if(CurrentLayer > MaxLayer)
            {
                CurrentLayer = 0 + CurrentLayer - MaxLayer;
            }
            if(CurrentLayer < 0)
            {
                CurrentLayer = MaxLayer + CurrentLayer;
            }
        }
        Layer = GameObject.Find("Map/"+CurrentLayer);
        Layer.GetComponent<Collider2D>().enabled = true;
        for(int i = 0; i < MaxLayer; i++)
        {
            Layer = GameObject.Find("Map/"+i);
            if(CurrentLayer - i >= 0 & CurrentLayer - i <= 3 )
            {
                float Brightness = 1-(i/0.2f);
                Layer.GetComponent<Renderer>().enabled = true;
                Layer.GetComponent<Tilemap>().color = new Color(Brightness,Brightness,Brightness,1);
            }
            else
            {
                Layer.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
