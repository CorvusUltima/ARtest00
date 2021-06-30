using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UpdateSceneNameText : MonoBehaviour
{


    public Text sceneName;
   
    // Update is called once per frame
    void Update()
    {
        sceneName.text = SceneManager.GetActiveScene().name.ToString();
    }
}
