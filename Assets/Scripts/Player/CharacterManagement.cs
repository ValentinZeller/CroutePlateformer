using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManagement : MonoBehaviour
{
    public GameObject antoine;
    public GameObject daniel;

    public Vector3 voidPos = new Vector3(-25, 0);

    public bool isAntoine = true;
    // Start is called before the first frame update
    void Start()
    {
        if (isAntoine)
        {
            antoine.transform.position = transform.position;
            daniel.transform.position = voidPos;
        } else
        {
            antoine.transform.position = voidPos;
            daniel.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchCharacter();
        }

    }

    void SwitchCharacter()
    {
        isAntoine = !isAntoine;

        if (isAntoine)
        {
            antoine.transform.position = daniel.transform.position;
            daniel.transform.position = voidPos;
        }
        else
        {
            daniel.transform.position = antoine.transform.position;
            antoine.transform.position = voidPos;
        }
    }
}
