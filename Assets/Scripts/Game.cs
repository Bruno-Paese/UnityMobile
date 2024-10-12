using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameState
{
    InGame, EndGame
}

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    public int points = 0;
    public float currentTimer = 20f;

	public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timerText;

    public GameState state = GameState.InGame;

	public TextMeshProUGUI currentPointText;
	public TextMeshProUGUI recordText;
	public TextMeshProUGUI newRecordText;

    public GameObject InGameUI, EndGameUI;

    public Transform TargetsTransform;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
		EnableRandomTargets();
    }

	public void EnableRandomTargets()
	{
		int childCount = TargetsTransform.childCount;
		int randomIndex = Random.Range(0, childCount);
		TargetsTransform.GetChild(randomIndex).gameObject.GetComponent<Target>().target.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            timerText.text = currentTimer.ToString("0") + "s";
            return;
        }

        state = GameState.EndGame;

        InGameUI.SetActive(false);
        EndGameUI.SetActive(true);
        currentPointText.text = points.ToString();
        newRecordText.gameObject.SetActive(false);
        recordText.text = PlayerPrefs.GetInt("points", 0).ToString();

        if (PlayerPrefs.GetInt("points", 0) < points)
        {
            PlayerPrefs.SetInt("points", points);
            recordText.text = points.ToString();
            newRecordText.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
