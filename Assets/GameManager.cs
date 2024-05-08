using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    
    [Header("Puzzle UI and Logic")]
    public List<GameObject> pieces;
    public int piecesInRightPosition = 0;
    
    public GameObject puzzleFrame;
    
    public TextMeshProUGUI titleText;
    public Button startButton;
    
    public TextMeshProUGUI winText;
    
    [Header("SFX")]
    public AudioSource audioChannel;
    
    public AudioClip correctSFX;
    public AudioClip wrongSFX;
    
    [Header("Time")]
    public int gameTime = 0;
    public TextMeshProUGUI timeText;
    
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
            winText.gameObject.SetActive(true);
            StopAllCoroutines();
        }
    }
    
    public void RandomizePieces()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].GetComponent<Piece>().Reset();
        }
    }
    
    public void StartGame()
    {
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        
        timeText.gameObject.SetActive(true);
        puzzleFrame.SetActive(true);
        for (int i = 0; i < pieces.Count; i++)
        {
            // pieces[i].GetComponent<Piece>().Reset();
            pieces[i].SetActive(true);
        }
        StartCoroutine(CountTime());
    }
    
    private IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTime++;
            timeText.text = TimeSpan.FromSeconds(gameTime).ToString(@"mm\:ss");
        }
    }
}
