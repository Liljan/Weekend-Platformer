using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    private Camera camera;
    public Transform player;
    private Transform yTransform;

    public float smoothness;
    private float offset;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start ()
    {
        PlayerEvents.Instance().TouchPlatform += SetTarget;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x, y, z;
        //Vector3 = camera.scree
        if(!yTransform)
        {
            x = player.position.x;
            y = player.position.y;
        }
        else
        {
            x = player.position.x;
            y = yTransform.position.y + offset;
        }

        z = transform.position.z;

        Vector2 lerp = Vector2.MoveTowards(transform.position, new Vector2(x, y), smoothness * Time.deltaTime);

        float finalX = x;
        float finalY = lerp.y;
        float finalZ = z;

        camera.transform.position = new Vector3(finalX,finalY,finalZ);
	}

    public void SetTarget(Transform t, float o)
    {
        yTransform = t;
        offset = o;
    }
}
