using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Vector2 velocity;

    public float smoothX;
    public float smoothY;

    public GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    void FixedUpdate(){
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x,ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothY);

        transform.position = new Vector3(posX, posY + .5f, transform.position.z);
    }
}
