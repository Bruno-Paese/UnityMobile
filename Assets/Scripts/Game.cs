using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    public int points = 0; 
	public TextMeshProUGUI pointsText;
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
    }
}
