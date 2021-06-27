using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFolowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject miniMapCamera;
    [SerializeField]
    private int plainDepthPos =0;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(miniMapCamera.transform.position.x, plainDepthPos, miniMapCamera.transform.position.z-2);

    }

}
