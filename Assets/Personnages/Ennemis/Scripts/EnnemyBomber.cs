using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnnemyBomber : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject drone;
    public GameObject bomb;
    private Animator bombanim;
    // Start is called before the first frame update
    void Start()
    {
        anim = drone.GetComponent<Animator>();
        bombanim = bomb.GetComponent<Animator>();
        StartCoroutine(Dropbomb());
    }

    IEnumerator Dropbomb()
    {
        yield return new WaitForSeconds(1);
        GameObject Bomb = Instantiate(bomb, new Vector2(drone.transform.position.x, drone.transform.position.y - 0.5f), Quaternion.identity);
        Bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
        yield return new WaitForSeconds(1);
        StartCoroutine(Dropbomb());
    }
    
}
