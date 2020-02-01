using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSetUp : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sprite;
    private float size = 0.1f;
    private float blobsHit = 0;
    private Vector3 startSize = new Vector3(0.01f, 0.01f, 1);
    [SerializeField] private GameObject bloodObject;
    [SerializeField] private Sprite[] sprites;

    private void Awake()
    {
        StartCoroutine(LivingFade());
        sprite.sprite = sprites[Random.Range(0, 4)];
    }

    public void IncreaseBlood()
    {
        blobsHit++;

        if (blobsHit >= 11)
        {
            return;
        }
        else
        {
            size = 0.01f * blobsHit;
            Vector3 scale = new Vector3(size, size, 1);
            bloodObject.transform.localScale = scale;
        }
    }

    private IEnumerator LivingFade()
    {
        yield return new WaitForSeconds(0.5f);
        Color startColour = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        Color endColour = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

        for (float t = 0.0001f; t < 2.0; t += Time.deltaTime)
        {
            float progress = t / 2.0f;
            sprite.color = startColour + (endColour - startColour) * progress;
            yield return null;
        }
        sprite.color = endColour;
        Destroy(this.gameObject.transform.parent.gameObject);
        yield return null;
    }
}
