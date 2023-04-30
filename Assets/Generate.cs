using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject section;
    public int zPos = 60;
    public bool isCreating = false;

    void Update()
    {
        if (!isCreating)
        {
            isCreating = true;
            StartCoroutine(GenerateSection());
        }
    }

    private IEnumerator GenerateSection()
    {
        Instantiate(section, new Vector3(-10.26963f, 14f, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(10);
        isCreating = false;
    }
}
