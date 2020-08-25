using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float offsetSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Camera follows player - without offset */
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, transform.position.z);
       
        /* Doesn not work
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0.0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        */
    }
}
