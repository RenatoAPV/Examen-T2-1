using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var posx = player.position.x;
        var posy = player.position.y;
        transform.position = new Vector3(posx, posy, transform.position.z);
    }
}
