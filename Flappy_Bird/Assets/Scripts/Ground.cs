using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    private GameObject lastGround;
    private Bird bird;

    private Queue<GameObject> queueGround;
    void Start()
    {
        queueGround = new Queue<GameObject>();
        bird = GameObject.FindObjectOfType<Bird>();
        CreateGround();
        CreateGround();
        CreateGround();
    }

    // Update is called once per frame
    void Update()
    {
        if(!bird.gameOver)
        {
            UpdateGround();
        }
    }

    private void UpdateGround()
    {
        foreach(GameObject ground in queueGround)
        {
            ground.transform.position += Vector3.left * 0.02f;
        }
        if(queueGround.Count > 0)
        {
            if(queueGround.Peek().transform.position.x < -30.0f)
            {
                CreateGround();
                Destroy(queueGround.Dequeue());
            }
        }
    }

    private void CreateGround()
    {
        GameObject newGround = Instantiate(ground);
        if(queueGround.Count > 0)
        {
            newGround.transform.position = lastGround.transform.position + (Vector3.right * 26.4f);
        }
        else
        {
            ground.transform.position = Vector3.zero;
        }
        lastGround = newGround;
        queueGround.Enqueue(newGround);
    }
}
