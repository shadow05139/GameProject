
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject activeCheckpoint;

    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        player.transform.position = activeCheckpoint.transform.position;
    }
}
