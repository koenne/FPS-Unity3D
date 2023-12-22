using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthbar : MonoBehaviour
{
    public GameObject go;
    public playerHealth playerHealth;
    public TMP_Text messageText;
    private float rounded;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Player");
        playerHealth = go.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        rounded = UnityEngine.Mathf.Round(playerHealth.health);
        messageText.SetText(rounded + " | 100");
    }
}
