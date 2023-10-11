interface IHaveWeapon
{
    string Weapon { get;set; }
    bool IsFire { get;set; }
    int NumberOfBullets { get;set; }

    void UserWeapon();
}