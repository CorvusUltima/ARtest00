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
        public float y;
        public int length;
        public string axis;
    }
    [System.Serializable]
    private class PipeList
    {
        public Pipe[] pipe;
    }
    private PipeList pipes = new PipeList();
    public GameObject pipeCube;

    void Awake()
    {
        pipes = JsonUtility.FromJson<PipeList>(jsonFile.text);

        for (int i = 0; i < pipes.pipe.Length; i++)
        {
            DrawPipe(pipeCube, pipes.pipe[i].x, pipes.pipe[i].y, pipes.pipe[i].length, pipes.pipe[i].axis);
        }
    }

    void DrawPipe(GameObject cube, float x, float z, int length, string axis)
    {
        switch (axis)
        {
            case "x":
                for (float i = 0; i < (float)length; i += 1f)
                {
                    DrawCube(cube, x + i, z);
                }
                break;
            case "z":
                for (float i = 0; i < (float)length; i += 1f)
                {
                    DrawCube(cube, x, z + i);
                }
                break;
            default: //Error
                break;
        }
    }
    void DrawCube(GameObject cube, float x, float z)
    {
        cube = Instantiate(cube, new Vector3(x, -0.5f, z), Quaternion.identity);
        cube.transform.parent = this.transform;
    }
}
