using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Section[] sectionPrefabs;
    public List<Section> sections = new List<Section>();
    public int totalSections = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSection();
        SpawnSection();
        SpawnSection();
    }

    // Update is called once per frame
    void SpawnSection()
    {
        int randomIndex = Random.Range(0, sectionPrefabs.Length);
        Section currentSection = Instantiate(sectionPrefabs[randomIndex], new Vector3(0, 0, totalSections*100), Quaternion.identity);
        sections.Add(currentSection);
        totalSections++;
    }
}
