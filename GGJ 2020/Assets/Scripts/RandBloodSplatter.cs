using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandBloodSplatter : MonoBehaviour
{
    [SerializeField] List<Sprite> splatters = new List<Sprite>();

    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        NewSplatter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewSplatter()
    {
        int rand = UnityEngine.Random.Range(0, splatters.Count);

        float min = 2.0f;
        float max = 5.0f;

        img.sprite = splatters[rand];
        transform.Rotate(0, 0, Random.Range(0, 360));
        Vector3 scal = transform.localScale;
        scal.x *= Random.Range(min, max);
        scal.y *= Random.Range(min, max);
        transform.localScale = scal;
    }
}
