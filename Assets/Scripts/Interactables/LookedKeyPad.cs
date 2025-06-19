using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookedKeyPad : Interactable
{
    public PlayerItems plItems;

    [Header ("Key Requirement")]
    public int needSilverKeysToUnlocked = 0;
    public int needGoldedKeysToUnlocked = 0;
    public int needBlueKeysToUnlocked = 0;

    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    private bool isDoorLooked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        if (isDoorLooked)
        {
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        }
        else
        {
            if (keyCheck())
            {
                doorOpen = !doorOpen;
                door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
                isDoorLooked = true;
                prompMessage = "Use Keypad";
                plItems.silverKeysCount -= needSilverKeysToUnlocked;
                plItems.goldenKeysCount -= needGoldedKeysToUnlocked;
                plItems.blueKeysCount -= needBlueKeysToUnlocked;
            }
        }
    }

    bool keyCheck()
    {
        return plItems.silverKeysCount >= needSilverKeysToUnlocked &&
                plItems.goldenKeysCount >= needGoldedKeysToUnlocked &&
                plItems.blueKeysCount >= needBlueKeysToUnlocked;
    }
}
