using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModels : MonoBehaviour
{
    [SerializeField] private GameObject[] spot1 = new GameObject[0];
    [SerializeField] private GameObject[] spot2 = new GameObject[0];
    [SerializeField] private GameObject[] spot3 = new GameObject[0];
    private int spotIndex = 0;

    public void IncreaseNumber()
    {
        spotIndex += 1;
        if (spotIndex > 2)
            spotIndex = 0;
        Debug.Log(spotIndex);
        ManageModels(spotIndex);
    }

    public void DecreaseNumber()
    {
        spotIndex -= 1;
        if (spotIndex < 0)
            spotIndex = 2;
        Debug.Log(spotIndex);
        ManageModels(spotIndex);
    }

    private void ManageModels(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (index == i)
            {
                spot1[i].SetActive(true);
                spot2[i].SetActive(true);
                spot3[i].SetActive(true);
            }
            else
            {
                spot1[i].SetActive(false);
                spot2[i].SetActive(false);
                spot3[i].SetActive(false);
            }
        }
    }
}