using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnGoals : MonoBehaviour
{
    [SerializeField] private GameObject goal1Spanwner;
    [SerializeField] private GameObject goal2Spanwner;
    [SerializeField] private GameObject goal3Spanwner;
   
    [SerializeField] private GameObject goalPrefab;

    private ObjectComparerGeneral _objectComparerGeneral;
    private List<string> goals = new List<string>{"Cube", "Sphere", "Cylinder", "Capsule"};
    // Start is called before the first frame update
    void Start()
    {
        _objectComparerGeneral = FindObjectOfType<ObjectComparerGeneral>();
        int i = 0;
        GameObject[] goalSpanwers = new GameObject[]{goal1Spanwner, goal2Spanwner, goal3Spanwner};
        foreach (var spanwer in goalSpanwers)
        {
            string text = goals[Random.Range(0, goals.Count)];
            
            goals.Remove(text);
            gameObject.name = text + "Goal";
            GameObject goal = Instantiate(goalPrefab, spanwer.transform.position, Quaternion.identity);
            goal.GetComponent<GoalPlacedGeneral>().num = i;
            _objectComparerGeneral.goals.Add(goal);
            goal.GetComponentInChildren<TextMeshPro>().text = text;
            i++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
