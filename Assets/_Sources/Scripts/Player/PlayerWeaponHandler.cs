using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerWeaponry Weaponry { get; private set; }

    [SerializeField] private float weaponsNumberToCarry = 2;
    [SerializeField] private Tag WeaponTag;

    private EncounteredWeapon _encounteredWeapon;

    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Weaponry = GetComponentInChildren<PlayerWeaponry>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.ChangeActionModeOnPickUp();
    }

    // Update is called once per frame
    private void Update()
    {
        //_encounteredWeapon = Player.Core.CollisionSenses.EncounteredWeapon;

        //do events
        if (Weaponry.CanSwitchWeapons)
        {
            InputHandler.EnableWeaponSwitch();
        }
        else
        {
            InputHandler.DisableWeaponSwitch();
        }

        if (InputHandler.IsSwitchWeaponButtonPressed)
        {
            Weaponry.SwitchWeapon();
        }

        if (_encounteredWeapon.Weapon != null)
        {
            InputHandler.ChangeActionModeOnPickUp();

            if (InputHandler.IsPickUpButtonPressed && Weaponry.CarriedWeapons.Count < weaponsNumberToCarry)
            {
                Weaponry.EquipWeapon(_encounteredWeapon.Weapon);
                //InputHandler.EnableWeaponSwitchButton();
                _encounteredWeapon.Weapon = null;


            }
            else if (InputHandler.IsPickUpButtonPressed && Weaponry.CarriedWeapons.Count >= weaponsNumberToCarry)
            {
                Weaponry.DropCurrentWeapon(_encounteredWeapon.Position);
                Weaponry.EquipWeapon(_encounteredWeapon.Weapon);
            }
            //otherwise drop current and pick - up new
        }
        else
        {
            InputHandler.ChangeActionModeOnAttack();
        }

        // ATTACK
        if (InputHandler.IsAttackButtonPressed && Weaponry.CurrentWeapon != null)
        {
            Weaponry.CurrentWeapon.Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.HasTag(WeaponTag))
        {
            _encounteredWeapon.Position = collision.transform;
            _encounteredWeapon.Weapon = collision.GetComponent<PlayerWeapon>();
        }
    }
}