using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RepeatGround : MonoBehaviour
{
    public Tilemap GroundPrefab;

    public Camera MainCamera;

    public Tilemap firstground;

    private Tilemap lastground;

    private float pos;

    private void Start()
    {
        Debug.Log("OE");
        pos = firstground.transform.position.x;
        CreateGround();
    }

    private void Update(){
        if(firstground.transform.position.x < MainCamera.transform.position.x - 530f){
            firstground = lastground;
            CreateGround();
        }
    }

    private void CreateGround(){
        Tilemap newTilemap = Instantiate(GroundPrefab, new Vector2(pos, 4f + 0.5899966f + 0.3300040f), Quaternion.identity, transform);
        lastground = newTilemap;
        pos += 124f;
    }
}
