using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    [SerializeField]
    private GameObject lid;
    private bool lidOpen;

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
        lidOpen = !lidOpen;
        lid.GetComponent<Animator>().SetBool("IsOpen", lidOpen);
    }
}
