using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Activate(GameObject player)
    {
        Debug.Log(gameObject.name + " activaed by " + player.name);
        Instantiate(powerup,player.transform);
        gameObject.SetActive(false);
    }
}
