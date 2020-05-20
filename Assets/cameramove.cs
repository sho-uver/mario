using System.Collections;
using UnityEngine;

public class cameramove: MonoBehaviour
{
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("マリオ");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
        
    }
}
