using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClose : MonoBehaviour
{
    public GameObject Object;
    public GameObject jerald;

    public void CloseObject()
    {
        if (Object != null)
        {
            Object.SetActive(false);
        }
    }
    public void openJerald()
    {
        if (jerald != null)
        {
            jerald.SetActive(true);
        }
    }
}
