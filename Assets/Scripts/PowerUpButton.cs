using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    [field:SerializeField] public Image Background { get; private set; }
    [SerializeField] private Image icon;
    [SerializeField] private Button button;
    
    public void SetUp(PowerUps powerUps, Sprite powerUpIcon)
    {
        icon.sprite = powerUpIcon;
        button.onClick.AddListener(powerUps.TryTrigger);
    }
}