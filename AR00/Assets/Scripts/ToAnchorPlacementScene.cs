using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToAnchorPlacementScene : MonoBehaviour
{
    public void changeScene()

    {
        if (SceneManager.GetActiveScene().name.ToString() == "GameAR00")
        { SceneManager.LoadScene("GameAR01"); }
        if (SceneManager.GetActiveScene().name.ToString() == "GameAR01")
        { SceneManager.LoadScene("GameAR00"); }
    }


}
