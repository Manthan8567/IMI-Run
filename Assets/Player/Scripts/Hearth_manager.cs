using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearth_manager : MonoBehaviour
{
    public GameObject[] health_bar;
    public int hearth = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        displayhearths(hearth);

    }

    public void displayhearths(int index)
    {
        for (int i = 0; i < health_bar.Length; i++)
        {
            if (i < hearth)
            {
                health_bar[i].SetActive(true);
            }
            else
                health_bar[i].SetActive(false);
        }
    }
}
