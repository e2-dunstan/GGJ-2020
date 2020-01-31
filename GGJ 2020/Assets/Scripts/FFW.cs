using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFW : MonoBehaviour
{
    private Color ffw;
    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        StartCoroutine(Ffw());
    }

    private IEnumerator Ffw()
    {
        Color startColour = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        Color endColour = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

        for (float t = 0.0001f; t < 1.0f; t += Time.deltaTime)
        {
            float progress = t / 1.0f;
            sprite.color = startColour + (endColour - startColour) * progress;
            yield return null;
        }
        sprite.color = endColour;
        yield return null;
    }
}
