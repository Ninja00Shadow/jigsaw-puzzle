using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject selectedPiece;
    public int orderInLayer = 1;

    void Start()
    {
        selectedPiece = null;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit && hit.transform.CompareTag("PuzzlePiece"))
            {
                if (!hit.transform.GetComponent<Piece>().isInRightPosition)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<Piece>().isSelected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = orderInLayer;
                    orderInLayer++;
                }
            }
        }

        if (selectedPiece && Input.GetMouseButtonUp(0))
        {
            selectedPiece.GetComponent<Piece>().isSelected = false;

            ChechIfWrongPosition();
            
            selectedPiece = null;
        }

        if (selectedPiece != null)
        {
            selectedPiece.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    
    private void ChechIfWrongPosition()
    {
        if (selectedPiece && Vector3.Distance(selectedPiece.transform.position, selectedPiece.GetComponent<Piece>().rightPosition) > 0.5f)
        {
            GameManager.Instance.PieceNotInRightPosition();
            ReturnPieceToInitialPosition();
        }
    }
    
    private void ReturnPieceToInitialPosition()
    {
        if (selectedPiece)
        {
            selectedPiece.GetComponent<Piece>().ReturnToInitialPosition();
        }
    }
}