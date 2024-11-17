using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardFactory cardFactory;
    [SerializeField] private Transform handTransform;

    public void Start()
    {
        // if (cardFactory == null)
        // {
        //     Debug.LogError("cardFactory не задан в инспекторе.");
        //     return;
        // }
        // if (handTransform == null)
        // {
        //     Debug.LogError("handTransform не задан в инспекторе.");
        //     return;
        // }

        // Debug.LogError("Start is work .");
        // CreateCardInHand("New Card", null);
    }

    void CreateCardInHand(string cardName, Sprite cardImage)
    {
        GameObject newCard = cardFactory.CreateCard(handTransform, cardName, cardImage);
        if (newCard != null)
        {
            Debug.Log("Карта успешно создана: " + cardName);
        }
        else
        {
            Debug.LogError("Ошибка создания карты: " + cardName);
        }
    }


}