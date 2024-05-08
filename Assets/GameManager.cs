using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    
    public List<GameObject> pieces;
    public int piecesInRightPosition = 0;
    
    [Header("SFX")]
    public AudioSource audioChannel;
    
    public AudioClip correctSFX;
    public AudioClip wrongSFX;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    void Update()
    {
        
    }
    
    public void PieceInRightPosition()
    {
        piecesInRightPosition++;
        audioChannel.PlayOneShot(correctSFX);

        if (piecesInRightPosition == pieces.Count)
        {
            YouWin();
        }
    }
    
    public void PieceNotInRightPosition()
    {
        audioChannel.PlayOneShot(wrongSFX);
    }
    
    public void YouWin()
    {
        if (piecesInRightPosition == pieces.Count)
        {
            Debug.Log("You Win!");
        }
    }
}
