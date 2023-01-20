using UnityEngine;

sealed public class StageManager : MonoBehaviour
{
    static public StageManager Instance;
    public int AmountActiveEnemiesInStage
    {
        get => amountActiveEnemiesInStage; 
        set 
        {
            amountActiveEnemiesInStage = value;
            if(amountActiveEnemiesInStage <= 0) {
                pause = true;
                OnChangedStage?.Invoke();
            }
        }
    }
    public bool pause = false;
    public delegate void ChangedStageEvent();
    public event ChangedStageEvent OnChangedStage;
    public int stage = 0;

    [SerializeField] private int amountEnemiesInStage;
    [SerializeField] private Spawner spawner;
    [SerializeField] private LocationMovement locationMovement;

    private int amountActiveEnemiesInStage = 0;

    private void Awake() 
    {
        if(Instance == null)
            Instance = this;

        OnChangedStage += AddStage;
        stage = 0;
        AddStage();
    }
    public void SetStagePause(bool pause)
    {
        this.pause = pause;
        OnChangedStage?.Invoke();
    }

    private void AddStage()
    {
        if(!pause)
        {
            stage++;
            AmountActiveEnemiesInStage = amountEnemiesInStage;
            spawner.AddGroup(amountEnemiesInStage);
        }
    }
}