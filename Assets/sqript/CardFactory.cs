using UnityEngine;

public class CardFactory : MonoBehaviour
{
    // Префаб карты, который будет клонироваться для создания новых карт
    [SerializeField] private GameObject cardPrefab;

    // Метод для создания карты
    public GameObject CreateCard(Transform parent, string cardName, Sprite cardImage)
    {
        // Создаем копию префаба карты
        GameObject newCard = Instantiate(cardPrefab, parent);
        
        // Задаем имя и изображение карты, если они используются
        newCard.name = cardName;
        var cardComponent = newCard.GetComponent<CardSrc>();
        if (cardComponent != null)
        {
            // Здесь можно передавать данные, которые нужны для настройки самой карты,
            // например, через свойства класса CardSrc или другие компоненты на newCard
        }

        // Установка изображения, если оно есть
        if (cardImage != null)
        {
            newCard.GetComponent<SpriteRenderer>().sprite = cardImage;
        }

        return newCard;
    }
}
