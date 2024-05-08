using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject selectedPiece;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.transform.CompareTag("PuzzlePiece"))
            {
                selectedPiece = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }

        if (selectedPiece != null)
        {
            selectedPiece.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}