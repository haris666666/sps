[System.Serializable]
public class WeaponData
{
    public int weaponID;
    public int level;
    public int damage;
    public float delayAttack;
    public IAttackBehaviour attackBehaviour;

    public WeaponData(int weaponID, int level, int damage, float delayAttack, IAttackBehaviour attackBehaviour)
    {
        this.weaponID = weaponID;
        this.level = level;
        this.damage = damage * level;
        this.delayAttack = delayAttack;
        this.attackBehaviour = attackBehaviour;
    }
    public WeaponData() {}
    public void UpLevel()
    {
        level++;
        damage *= level;
    }
    
}