using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
  [SerializeField] int startingMany = 150;
  [SerializeField] int currnetBalance ;
  [SerializeField] TextMeshProUGUI displayBalance;
  public int CurrentBalance{get {return currnetBalance;}}

    void Awake() {
        currnetBalance = startingMany;
        UpdateDisplay();
    }
     public void Deposit(int amount)
    {
        currnetBalance +=Mathf.Abs(amount);
        UpdateDisplay();

    }
    public void WithDrawMoney(int amount)
    {
        currnetBalance -=Mathf.Abs(amount);
        UpdateDisplay();
        
        if(currnetBalance < 0)
        {
            RelodScene();
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Gold:"+CurrentBalance;
        
    }
    void RelodScene()
    {
        Scene currentScene =SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
 
