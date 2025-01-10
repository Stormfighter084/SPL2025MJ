using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cave : MonoBehaviour
{
    public Tilemap cave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cave.GetComponent<TilemapRenderer>().enabled = false;
        Debug.Log("1");
    }
}
