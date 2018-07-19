using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManager : MonoBehaviour {

    #region Singleton
    public static BlueprintManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Blueprint> blueprints;

    public void AddBluePrint(Blueprint blueprint)
    {
        if (blueprints.Contains(blueprint))
        {
            return;
        }

        PopupText.instance.PopUp(1, blueprint.unlockedRecipe.Result, true, blueprint);

        Debug.Log("Aquired new Blueprint: " + blueprint.unlockedRecipe.Result.name);
        blueprints.Add(blueprint);
    }
}