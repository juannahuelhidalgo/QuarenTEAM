using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//comentario 
public class menuPrinc : MonoBehaviour
{
    public Texture2D[] frames0;
    public double fps;
    bool reproduciendo = false;

    void Update()
    {
        StartCoroutine(menuReprod());
    }

    void Start()
    {
        menuReprod();
    }

    IEnumerator menuReprod()
    {
        int indice = (int)(Time.time * fps % frames0.Length);
        GetComponent<RawImage>().texture = frames0[indice];
        yield return new WaitForSeconds(1);
        reproducido();
    }

    public void reproducido()
    {
        reproduciendo = true;
    }
}
