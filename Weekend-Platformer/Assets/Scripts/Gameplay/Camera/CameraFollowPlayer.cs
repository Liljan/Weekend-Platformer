using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    private Camera camera;
    public Transform target;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 = camera.scree

        float x = target.position.x;
        float y = transform.position.y;
        float z = transform.position.z;



        transform.position = new Vector3(x,y,z);
	}
}
