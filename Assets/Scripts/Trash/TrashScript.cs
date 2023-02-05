using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SoundEffectController))]
public class TrashScript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public SoundEffectController SoundEffectController; 

    public float FadeRate = 0.05f; 
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer= GetComponent<SpriteRenderer>();
        SoundEffectController= GetComponent<SoundEffectController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fade()
    {
        StartCoroutine(FadeObject());
    }

    IEnumerator FadeObject()
    {
        yield return null;
        SoundEffectController.PlaySound("Fade"); 
        while (SpriteRenderer.color.a > 0)
        {
            SpriteRenderer.color 
                = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, SpriteRenderer.color.a - FadeRate);
            yield return new WaitForSeconds(0.1f); 
        }

        Destroy(gameObject);
    }    
}
