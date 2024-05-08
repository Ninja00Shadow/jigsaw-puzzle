using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Piece : MonoBehaviour
{
    public Vector3 rightPosition;
    public Vector3 initialPosition;
    public bool isInRightPosition;
    public bool isSelected;

    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-7.0f, -2.0f), Random.Range(-3.0f, 3.0f), 0);
        initialPosition = transform.position;
        isInRightPosition = false;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!isSelected && !isInRightPosition)
            {
                transform.position = rightPosition;
                isInRightPosition = true;
                GetComponent<SortingGroup>().sortingOrder = 0;

                GameManager.Instance.PieceInRightPosition();
            }
        }
    }

    public void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }
}