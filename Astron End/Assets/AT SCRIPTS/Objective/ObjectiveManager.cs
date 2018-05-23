using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour {

    public TextMeshProUGUI Text;
    public GameObject skipText;

    public Animation anim;

    public List<string> currentObjectives;
    public List<bool> currentStates;
    public List<int> currentPriorities;

    public List<string> priList;

    private void Update()
    {
        if(currentPriorities.Count >= 1)
        {
            if (currentPriorities[0] == 1)
            {
                if(currentObjectives[0] == "No Objectives")
                {
                    skipText.SetActive(false);
                }
                skipText.SetActive(false);
            }
            else
            {
                skipText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.O))
                {
                    SkipObjective();
                }
            }
        }
    }

    public void Objective(Objective obj)
    {
        if (currentObjectives.Count >= 1) 
        {
            if(currentObjectives[0] == "No Objective")
            {
                currentObjectives.Remove(currentObjectives[0]);
            }
        }

        #region AddObjective
        if (obj.objective != null)
        {
            foreach(string objective in currentObjectives)
            {
                if(objective == obj.objective)
                {
                    CheckObjective();
                    return;
                }
            }

            currentObjectives.Add(obj.objective);
            currentStates.Add(obj.ObjDone);
            currentPriorities.Add(obj.priority);
        }
        #endregion

        UpdateText();

        #region SeeIfFirstObjIsDone
        CheckObjective();
        #endregion
    }

    public void CompleteObjective(string objective)
    {
        if(objective == currentObjectives[0])
        {
            currentStates[0] = true;
            CheckObjective();
        }
    }

    public void CheckObjective()
    {
        if (currentStates[0] == true && currentObjectives.Count >= 2)
        {
            RemoveFromList(0);

            anim.Play();
        }
        else if(currentStates[0] == true && currentObjectives.Count == 1)
        {
            RemoveFromList(0);

            currentObjectives.Add("No Objective");
            anim.Play();
        }
    }

    public void UpdateText()
    {
        Text.text = currentObjectives[0];
    }

    public void SkipObjective()
    {
        currentStates[0] = true;
        CheckObjective();
    }

    void RemoveFromList(int i)
    {
        currentObjectives.Remove(currentObjectives[i]);
        currentStates.Remove(currentStates[i]);
        currentPriorities.Remove(currentPriorities[i]);
    }
}