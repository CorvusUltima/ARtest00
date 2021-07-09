using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesGenerator3d : MonoBehaviour
{
    public TextAsset jsonFile;
    [System.Serializable]
    private class Pipe
    {
        public float x;
        public float z;
        public int length;
        public string axis;
    }
    [System.Serializable]
    private class PipeList
    {
        public Pipe[] pipe;
    }
    private PipeList pipes = new PipeList();
    public GameObject pipeCyllinder;

    void Awake()
    {
        pipes = JsonUtility.FromJson<PipeList>(jsonFile.text);

        for (int i = 0; i < pipes.pipe.Length; i++)
        {
            DrawPipe(pipeCyllinder, pipes.pipe[i].x, pipes.pipe[i].z, pipes.pipe[i].length, pipes.pipe[i].axis);
        }
    }

    void DrawPipe(GameObject cyllinder, float x, float z, int length, string axis)
    {
        switch(axis)
        {
            case "x":
                for (float i = 0; i < (float)length; i += 1f)
                {
                    DrawCyllinder(cyllinder, x + i, z, axis);
                }
                break;
            case "z":
                for (float i = 0; i < (float)length; i += 1f)
                {
                    DrawCyllinder(cyllinder, x, z + i, axis);
                }
                break;
            default: //Error
                break;
        }
    }
    void DrawCyllinder(GameObject cyllinder, float x, float z, string axis)
    {
        cyllinder = Instantiate(cyllinder, new Vector3(x, -0.5f, z), Quaternion.Euler(90, 90 * System.Convert.ToInt32(axis == "x"), 0));
        cyllinder.transform.parent = this.transform;
    }
}
