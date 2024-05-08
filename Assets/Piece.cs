using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector3 rightPosition;
    public bool isInRightPosition;
    public bool isSelected;
    
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-7.0f, -2.0f), Random.Range(-3.0f, 3.0f), 0);
        isInRightPosition = false;
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!isSelected)
            {
                transform.position = rightPosition;
                isInRightPosition = true;
            }
        }
    }
}
