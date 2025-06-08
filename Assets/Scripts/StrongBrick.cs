using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : MonoBehaviour
{
    public int hitPoints = 3;
    public Sprite[] colorSprites;

    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeHit();
        }
    }

    private void TakeHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            FindObjectOfType<GameManager>().CheckLevelCompleted();
            Destroy(gameObject);
        }
        else
        {
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
        if (colorSprites.Length > 0)
        {
            int index = Mathf.Clamp(hitPoints - 1, 0, colorSprites.Length - 1);
            spriteRenderer.sprite = colorSprites[index];
        }
    }
}
