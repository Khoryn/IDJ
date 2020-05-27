using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private GameObject target;
    private void Awake()
    {
        inventory = new Inventory();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void Update()
    {
        target.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        target.transform.position = Vector3.Lerp(target.transform.position, transform.position, 0.1f);
    }
}
