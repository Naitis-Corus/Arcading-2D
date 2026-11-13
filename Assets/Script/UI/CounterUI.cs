using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] RectTransform arrowUI;
    [SerializeField] RectTransform sliderUI;
    [SerializeField] TextMeshProUGUI textUI;
    [SerializeField] RectTransform arrowRecordUI;
    [SerializeField] TextMeshProUGUI textRecordUI;
    [SerializeField] Image imageRecordUI;
    [SerializeField] float transparencyDistanceY = 55f;
    public int playerAltimeter { get; private set; } = 0;
    float normalizedAltitude = 0f;
    int RecordAltimeter = 0;
    float posForSlider = 0f;

    void Start()
    {
        RecordAltimeter = PlayerPrefs.GetInt("bestRecord", 0);
        if (RecordAltimeter == 0)
        {
            arrowRecordUI.gameObject.SetActive(false);
        }
        else
        {
            textRecordUI.text = $"{RecordAltimeter} M";
            normalizedAltitude = (float)RecordAltimeter / (RecordAltimeter + 1000);
            posForSlider = normalizedAltitude * sliderUI.rect.height;
            arrowRecordUI.anchoredPosition = new Vector2(arrowRecordUI.anchoredPosition.x, posForSlider);
        }

    }

    void Update()
    {
        if (playerAltimeter <= player.transform.position.y)
        {
            playerAltimeter = (int)player.transform.position.y;
        }
        textUI.text = $"{playerAltimeter} M";
        normalizedAltitude = (float)playerAltimeter / (playerAltimeter + 1000);
        posForSlider = normalizedAltitude * sliderUI.rect.height;


        arrowUI.anchoredPosition = new Vector2(arrowUI.anchoredPosition.x, posForSlider);
        if (playerAltimeter >= RecordAltimeter - transparencyDistanceY)
        {
            float remainingDistanceY = RecordAltimeter - playerAltimeter;
            float minDistanceY = 25f;
            float numberForAlpha = Mathf.InverseLerp(minDistanceY,transparencyDistanceY,remainingDistanceY);
            Color colorTemp = imageRecordUI.color;
            colorTemp.a = numberForAlpha;
            imageRecordUI.color = colorTemp;
            Color colorTempText = textRecordUI.color;
            colorTempText.a = numberForAlpha;
            textRecordUI.color = colorTempText;


        }
    }
}
