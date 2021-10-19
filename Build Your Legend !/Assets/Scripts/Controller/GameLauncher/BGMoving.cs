using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMoving : MonoBehaviour
{
    private Vector3 _limit;
    private bool moveLeft = false;
    private bool moveDown = false;
    private Vector3 initpos;
    private Image im;
    public Camera c;
    public GameObject g;

    // Start is called before the first frame update
    void Awake()
    {
        
        im = GetComponentInChildren<Image>();
        initpos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
        if(transform.localPosition.x <= -im.rectTransform.rect.width /2)
        {
            moveLeft = true;
        }
        else if(transform.localPosition.x >= initpos.x)
        {
            moveLeft = false;
        }
        if(transform.localPosition.y <= -im.rectTransform.rect.height /2)
        {
            moveDown = true;
        }else if(transform.localPosition.y >= initpos.y)
        {
            moveDown = false;
        }
        transform.position += new Vector3(moveLeft ? 20f*Time.deltaTime : -20f*Time.deltaTime, moveDown ? 20f*Time.deltaTime : -20f*Time.deltaTime, 0);
    }
}
