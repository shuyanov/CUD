using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

/// Структура
public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack, Defense;
    public Card(string name, string logoPath, int attack, int defense)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScr : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new Card("pepeAngry", "Sprites/Cards/pepeAngry", 5, 3));
        CardManager.AllCards.Add(new Card("pepeHead", "Sprites/Cards/pepeHead", 2, 8));
        CardManager.AllCards.Add(new Card("pepeMagick", "Sprites/Cards/pepeMagick", 10, 1));
        CardManager.AllCards.Add(new Card("pepePlancet", "Sprites/Cards/pepePlancet", 1, 1));
        CardManager.AllCards.Add(new Card("pepePunch", "Sprites/Cards/pepePunch", 7, 5));
        CardManager.AllCards.Add(new Card("pepeRofl", "Sprites/Cards/pepeRofl", 8, 2));
    }
}
