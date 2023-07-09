using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    [field:SerializeField] public float Duration { get; private set; }
    [field:SerializeField] public float CoolDown { get; private set; }

    public bool IsActive { get; private set; }
    public bool IsInCooldown { get; private set; }
    public abstract PowerUpTypes Types { get; }

    protected KeyCode ShortCut;

    private PowerUpButton _powerUpButton;
    private float _currentTimer;

    private float CurrentTimer
    {
        get => _currentTimer;
        set
        {
            _currentTimer = value;
            if (IsActive) _powerUpButton.Background.fillAmount = 1 - (_currentTimer / Duration);
            if (IsInCooldown) _powerUpButton.Background.fillAmount = _currentTimer / CoolDown;
        }
    }
    
    public void SetUp(KeyCode shortCut, PowerUpButton powerUpButton)
    {
        ShortCut = shortCut;
        _powerUpButton = powerUpButton;
    }
    
    private void Update()
    {
        if (IsActive || IsInCooldown)
        {
            CurrentTimer += Time.deltaTime;
        }
        if (IsActive)
        {
            if (CurrentTimer >= Duration)
            {
                CurrentTimer -= Duration;
                Deactivate();
                return;
            }
        }
        
        if (IsInCooldown)
        {
            if (CurrentTimer >= CoolDown)
            {
                CurrentTimer = CoolDown;
                IsInCooldown = false;
                IsActive = false;
                return;
            }
        }
        if (!Input.GetKeyDown(ShortCut)) return;

        TryTrigger();
    }

    public void TryTrigger()
    {
        if (IsActive || IsInCooldown) return;
        
        Trigger();
    }

    protected virtual void Trigger()
    {
        IsActive = true;
        IsInCooldown = false;
        CurrentTimer = 0;
    }

    protected virtual void Deactivate()
    {
        IsActive = false;
        IsInCooldown = true;
    }
}