using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandBloodSplatter : MonoBehaviour
{
    [SerializeField] List<Sprite> splatters = new List<Sprite>();

    private bool on = false;

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
        if (on)
        {
            Color col = img.color;
            col.a *= 0.99f;
            img.color = col;

            if (img.color.a == 0)
                Destroy(gameObject);
        }
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
        transform.localScale = scal * 0.1f;

        StartCoroutine("SizeIncrease", scal);

        on = true;
    }

    IEnumerator SizeIncrease(Vector3 _scal)
    {
        Vector3 newScale = transform.localScale;

        while (transform.localScale.x < _scal.x)
        {
            newScale *= 1.3f;
            transform.localScale = newScale;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
