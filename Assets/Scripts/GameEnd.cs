using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
   
    public GameObject Lose;
    void OnCollisionEnter(Collision collision)
    {
        Lose.SetActive(true);

    }
}
