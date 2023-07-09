using UnityEngine;

public class PowerUpUIManager : MonoBehaviour
{
    [SerializeField] private PowerUpButton firstPowerUpButton;
    [SerializeField] private PowerUpButton secondPowerUpButton;
    [SerializeField] private PowerUpButton thirdPowerUpButton;
    [SerializeField] private PowerUpTypeToIconConfiguration powerUpIcons;

    private PowerUps _firstPowerUps;
    private PowerUps _secondPowerUps;
    private PowerUps _thirdPowerUps;

    private void Awake()
    {
        var firstPowerUpType = PowerUpsTypesHelper.GetHandler(PowerUpInventory.FirstPowerUp);
        var secondPowerUpType = PowerUpsTypesHelper.GetHandler(PowerUpInventory.SecondPowerUp);
        var thirdPowerUpType = PowerUpsTypesHelper.GetHandler(PowerUpInventory.ThirdPowerUp);

        _firstPowerUps = FindObjectOfType(firstPowerUpType) as PowerUps;
        _secondPowerUps = FindObjectOfType(secondPowerUpType) as PowerUps;
        _thirdPowerUps = FindObjectOfType(thirdPowerUpType) as PowerUps;
        var firstIcon = powerUpIcons.Icons.Find(item => item.Type == _firstPowerUps.Types).Icon;
        var secondIcon = powerUpIcons.Icons.Find(item => item.Type == _secondPowerUps.Types).Icon;
        var thirdIcon = powerUpIcons.Icons.Find(item => item.Type == _thirdPowerUps.Types).Icon;

        _firstPowerUps.enabled = true;
        _secondPowerUps.enabled = true;
        _thirdPowerUps.enabled = true;
        
        firstPowerUpButton.SetUp(_firstPowerUps, firstIcon);
        secondPowerUpButton.SetUp(_secondPowerUps, secondIcon);
        thirdPowerUpButton.SetUp(_thirdPowerUps, thirdIcon);
        
        _firstPowerUps.SetUp(KeyCode.Alpha1, firstPowerUpButton);
        _secondPowerUps.SetUp(KeyCode.Alpha2, secondPowerUpButton);
        _thirdPowerUps.SetUp(KeyCode.Alpha3, thirdPowerUpButton);
    }
}