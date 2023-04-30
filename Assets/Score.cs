using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreTxt; 
  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            score ++;
            scoreTxt.text = "Score: " + score.ToString();
        }
    }
}
