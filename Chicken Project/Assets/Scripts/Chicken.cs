using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public AudioSource audioSource;
    public SpriteRenderer spriteRenderer;

    public Color color;
    public Head head;
    public Eyes eyes;

    public enum Color
    {
        Yellow,
        Red,
        Blue,
        Green,
        White,
        Grey
    }

    public enum Head
    {
        None,
        ArmyHelmet,
        BaseballCap
    }

    public enum Eyes
    {
        None,
        GlassesWhite,
        GlassesBlue,
        GlassesOrange,
        GlassesPink,
        SunGlassesWhite,
        SunGlassesBlue,
        SunGlassesOrange,
        SunGlassesPink
    }

    public enum Beak
    {
        Yellow,
        Red,
        Blue,
        Green,
        White,
        Grey
    }

    public void ChickenHit()
    {
        audioSource.Play();
        spriteRenderer.enabled = false;
    }

}
