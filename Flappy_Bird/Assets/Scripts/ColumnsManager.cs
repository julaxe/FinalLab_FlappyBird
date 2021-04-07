using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject columnBlock;
    private GameObject lastColumn;
    private Bird bird;

    private Queue<GameObject> queueColumns;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindObjectOfType<Bird>();
        queueColumns = new Queue<GameObject>();
        InitializeColumns();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.gameOver)
        {
            UpdateColumns();
        }
    }

    private void UpdateColumns()
    {
        foreach(GameObject column in queueColumns)
        {
            column.transform.position += (Vector3.left * 0.02f);
        }
        if(queueColumns.Count> 0)
        {
            if(queueColumns.Peek().transform.position.x < -9.5)
            {
                Destroy(queueColumns.Dequeue());
                createColumn();
            }
        }
    }
    private void InitializeColumns()
    {
        for(int i = 0; i < 10; i++) // create n columns
        {
            createColumn();
        }
    }

    private void createColumn()
    {
        GameObject newCol = Instantiate(columnBlock);
        float randomY = Random.Range(-2.0f, 1.0f);
        if(queueColumns.Count > 0)
        {
            float nextX = lastColumn.transform.position.x + (3.0f);
            newCol.transform.position = new Vector3(nextX, randomY, 1.0f);
        }
        else
        {
            newCol.transform.position = new Vector3(5.0f, randomY, 1.0f);
        }
        lastColumn = newCol;
        queueColumns.Enqueue(newCol);
    }
}
