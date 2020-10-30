using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOpener : MonoBehaviour
{
    public GameObject Object;
    public GameObject jerald;

    public void OpenObject()
    {
        if (Object != null)
        {
            Object.SetActive(true);
        }
    }
    public void closeJerald()
    {
        if (jerald != null)
        {
            jerald.SetActive(false);
        }
    }
}
