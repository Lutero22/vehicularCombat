using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    public GameObject Win;
    void OnCollisionEnter(Collision collision)
    {
        Win.SetActive(true);
    }
}
