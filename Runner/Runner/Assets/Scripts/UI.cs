using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("MenuPause")]

    public TextMeshProUGUI textCoins, textPoints, textRecord, labelRecord, textButton;
    public GameObject menu, pauseButton, continueButton;
    [Header("InGame")]

    public TextMeshProUGUI points, coins;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMenuPause()
    {
        Time.timeScale = 0;
        continueButton.SetActive(true);
        pauseButton.SetActive(false);
        populateMenu();
    }

    public void OpenMenuEnd()
    {
        continueButton.SetActive(false);
        pauseButton.SetActive(true);
        populateMenu();
    }

    void populateMenu()
    {
        menu.SetActive(true);
        textCoins.text = Game.instance.coins.ToString();
        textPoints.text = Game.instance.points.ToString();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void PlayAgain()
    {
        menu.SetActive(false);
    }
}
