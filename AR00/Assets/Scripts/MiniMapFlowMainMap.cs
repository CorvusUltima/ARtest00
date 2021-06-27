using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFlowMainMap : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject mainCammera;
    [SerializeField]
    private int miniCameraHeight = 50;
    // Update is called once per frame
    void Update()
    {
       this.transform.position = new Vector3(mainCammera.transform.position.x, miniCameraHeight, mainCammera.transform.position.z);

    }
}
