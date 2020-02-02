using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeSpawner : MonoSingleton<DudeSpawner>
{
    [SerializeField]private GameObject dudePrefab;
    
    public IEnumerator SpawnCompletedDudes()
    {
        for (int i = 0; i < GameManager.Instance.GetScore(); i++)
        {
            Instantiate(dudePrefab, transform);
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
}
