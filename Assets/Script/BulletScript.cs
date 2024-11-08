using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro.EditorUtilities;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float _cd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _cd -= Time.deltaTime;
        if (_cd < 0)
            Destroy(gameObject);
    }
}
