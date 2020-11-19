using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerChanger : MonoBehaviour, IComparer<SpriteRenderer>
{
    [SerializeField] SpriteRenderer[] sprites;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Array.Sort(sprites, Compare);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = i;
        }
    }


    public int Compare(SpriteRenderer x, SpriteRenderer y)
    {
        if (x.transform.position.y > y.transform.position.y)
            return -1;
        if (x.transform.position.y < y.transform.position.y)
            return 1;
        return 0;
    }
}
