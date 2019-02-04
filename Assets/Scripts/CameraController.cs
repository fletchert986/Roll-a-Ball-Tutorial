using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
