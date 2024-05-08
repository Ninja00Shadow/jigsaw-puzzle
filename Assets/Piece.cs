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
    public bool isReturning;

    void Start()
    {
        rightPosition = transform.position;
        
        Reset();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition) < 0.5f)
        {
            if (!isSelected && !isInRightPosition && !isReturning)
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
        StartCoroutine(Return());
    }
    
    public void Reset()
    {
        transform.position = new Vector3(Random.Range(-7.0f, -2.0f), Random.Range(-3.0f, 3.0f), 0);
        initialPosition = transform.position;
        isInRightPosition = false;
    }

    public IEnumerator Return()
    {
        isReturning = true;
        float elapsedTime = 0;
        float duration = 0.5f;
        Vector3 start = transform.position;
        Vector3 end = initialPosition;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = end;
        isReturning = false;
    }
}