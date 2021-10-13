using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tank abstract bir class olduğu için ondan türetilen classların fonskiyonu içermesi gerekir
public class playerTank : Tank
{
    public GameObject track;
    protected override void Move()
    {
        float moveAxis = Input.GetAxis("Vertical");
        float rotAxis = Input.GetAxis("Horizontal");

        //ilerleme
        rb.MovePosition(transform.position + transform.forward *moveSpeed*moveAxis*Time.deltaTime);

        //yalnızca y ekseninde döneceği için x ve z 0 olmalı
        //x=0 ve z=0, sadece y ekseninde dönecek, rotaxis*rotspeed
        Quaternion rot = Quaternion.Euler(0,rotAxis * rotSpeed * Time.deltaTime ,0);

        //dönme
        rb.MoveRotation(transform.rotation * rot);
        CreateMoveEffect(moveAxis*moveSpeed*Time.deltaTime);
    }

    IEnumerator current;

    private void Update()
        {
            if(Input.GetMouseButtonDown(0)) //press left mouse button
            {
                if(current != null)
                {
                    StopCoroutine(current);
                }

                current = TurnAndShoot();
                StartCoroutine(current);
            }
        }


    //tracka dönme efekti verildi.
    void CreateMoveEffect(float speed)
    {
        track.GetComponent<MeshRenderer>().sharedMaterial.mainTextureOffset += new Vector2(speed,0);
    }






    
}
