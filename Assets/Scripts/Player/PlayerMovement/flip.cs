using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    private bool faceLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void FaceLeft(GameObject obj, bool faceLeft)
    {
        if (faceLeft)
        {
            obj.transform.localScale = new Vector3(1, 1, -1);
        }
        else
        {
            obj.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
