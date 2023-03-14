using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled; 
    [SerializeField] GameObject gameOverScreen; 
    [SerializeField] Player player; 

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ShowGameOverScreen(); 
        }
    }

    void ShowGameOverScreen() 
    {
        gameOverScreen.SetActive(true); 
        //distanceTraveled.text = player.distanceTraveled.ToString(); 
        float roundDistance = Mathf.Ceil(player.distanceTraveled);  
        distanceTraveled.text = "" + roundDistance;   
    }
    public void GameRestart()
    { 
        Debug.Log("Restart the game"); 
    }
}
