using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changeimage : MonoBehaviour
{

    [Header("Sprite")]
    [SerializeField] private Image Sprite;

    [Header("Image")]
    [SerializeField] private Image img;

    [Header("Sprites")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite sprite1;

    public void ChangeSprite()
    {
        Sprite.sprite = sprite;

        img.sprite = sprite1;
    }
    public void BackChangeSprite()
    {
        img.sprite = sprite1;

        Sprite.sprite = sprite;
    }
}