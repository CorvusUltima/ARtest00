using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{

    public Text cordinates;

    private void Update()
    {
        cordinates.text = "Lat." + GPS.Instance.latitude.ToString() + "  Lon:" + GPS.Instance.longitude.ToString();
    }




}
