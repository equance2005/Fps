using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//武器射击部分
public class WeaponController : MonoBehaviour
{
    public Transform shooterPoint;//射击位置

    public int bulletsMag = 31;//弹夹子弹数量
    public int range = 100;//武器射程
    public int bulletLeft = 300; //备弹
    public int currentBullects;


    private bool GunShootInput;

    public float fireRate = 0.1f;
    private float fireTimer;

    [Header("键位设置")]
   [Tooltip("填装子弹按键")] public KeyCode reloadInputName;


    [Header("UI设置")] 
    public Image CrossHairUI;
    public Text AmmoTextUI;
    // Start is called before the first frame update
    void Start()
    {
        reloadInputName = KeyCode.R;
        currentBullects = bulletsMag;
        UpdateAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {

        GunShootInput = Input.GetMouseButton(0);
        if(GunShootInput)
        {
            GunFire();
        }

        if(Input.GetKeyDown(reloadInputName)&&currentBullects<bulletsMag&&bulletLeft>0)
        {
            Reload();
        }


        if(fireTimer< fireRate)
        {
            fireTimer += Time.deltaTime; 
        }
    }


    public void GunFire()
    {
        if (fireTimer < fireRate||currentBullects<=0 ) return;


        RaycastHit hit;
        Vector3 shootDirection = shooterPoint.forward;//射击·方向·
        if(Physics.Raycast(shooterPoint.position,shootDirection,out hit,range))
        {

        }
        currentBullects--;
        UpdateAmmoUI();
        fireTimer = 0;
    }



    public void Reload()
    {
        if (bulletLeft <= 0) return;

        int bullectToload =  bulletsMag - currentBullects;

        int bullectToReduce = (bulletLeft >= bullectToload) ? bullectToload : bulletLeft;
        bulletLeft -= bullectToReduce;
        currentBullects += bullectToload;
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        AmmoTextUI.text = currentBullects + " /" + bulletLeft;


    }
}
