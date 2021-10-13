using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerUI, enemyUI;

    Vector3 offset; //player-camera vektörü
    public float rotSpeed=5;
    public Transform player {get {return FindObjectOfType<playerTank>().transform; }}
    void Start()
    {
        //kameranın konumu
        offset = player.position - transform.position;
        
    }

    

    void LateUpdate()
    {

        //kameranın konumu
        transform.position = player.position - offset;

        //dönme yönünü fareyle ayarlamak istiyoruz. fareyi x etrafında yatayda döndürmek istiyoruz.
        //mouse x project settingsteki ismi
        Quaternion rot = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*rotSpeed, Vector3.up);
        offset = rot * offset; //verilen offset vektörünü verilen rotasyon kadar dööndürür.
        //bu rotasyonu offsete ekliyoruz çünkü dönmeyi sağlayacak olan offset vektörü

        //kameranın sürekli tanka bakması
        transform.LookAt(player.position);
        //kameranın ileri vektörünü tanka bakacak şekilde ayarlar


        SetUIRotation(playerUI);
        SetUIRotation(enemyUI);

    }

    private void SetUIRotation(Transform ui)
    {
        //ui konumu ile kamera konumu arasındaki fark
        Vector3 diff = (ui.position - transform.position).normalized;


        Quaternion lookRotation = Quaternion.LookRotation(diff);

        //ui.rotation = lookRotation; direkt dönmeyi sağlayan komut budur

        //dönmesi gereken ui rotation
        ui.rotation = Quaternion.Lerp(ui.rotation, lookRotation, Time.deltaTime*5);
        //Lerp ile yapılan işlemler yavaş dönüş için
        //lerp = iki doğrusal nokta arasında bölümler oluşturur bu sayede gecikme sağlar

    }
}
