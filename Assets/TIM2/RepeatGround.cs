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

    private List<Tilemap> groundList = new List<Tilemap>();

    private Vector3 posSpawn;

    private void Start()
    {
        posSpawn = firstground.transform.position;
        groundList.Add(firstground);
    }

    private void Update(){
        if (groundList.Count == 0) return;
        if(groundList[groundList.Count-1].transform.position.x < MainCamera.transform.position.x - 530f){
            CreateGround();
        }
    }

    private void CreateGround(){
        if (groundList.Count <= 1){
            Tilemap newTilemap = Instantiate(GroundPrefab, new Vector2(posSpawn.x, 4f + 0.5899966f + 0.3300040f), Quaternion.identity, transform);
            groundList.Add(newTilemap);
        }else{
            Tilemap newTilemap = groundList[0];
            newTilemap.transform.position = new Vector2(posSpawn.x, 4f + 0.5899966f + 0.3300040f);
            groundList.RemoveAt(0);
            groundList.Add(newTilemap);
        }
    }
}
