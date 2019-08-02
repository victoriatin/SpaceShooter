using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float time_elapsed;
    public float tileSizeZ;
    public GameController gameController;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        time_elapsed = 0f;
    }

    // Update is called once per frame
    public void Update()
    {
        if (gameController.score >= 100)
        {
             time_elapsed = Time.time + time_elapsed;  
          scrollSpeed = (Mathf.Lerp(-0.25f, -15f, time_elapsed));
        
        }
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
