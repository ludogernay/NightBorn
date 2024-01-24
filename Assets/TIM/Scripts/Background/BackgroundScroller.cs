using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollspeed = 0.25f;
    private float offset;
    // private Material mat;
    void Start()
    {
        // mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollspeed) / 10f;
        // mat.SetTextureOffset("_MainText", new Vector2(offset, 0));
    }
}
