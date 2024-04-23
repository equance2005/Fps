using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//�����������
public class WeaponController : MonoBehaviour
{
    public Transform shooterPoint;//���λ��

    public int bulletsMag = 31;//�����ӵ�����
    public int range = 100;//�������
    public int bulletLeft = 300; //����
    public int currentBullects;


    private bool GunShootInput;

    public float fireRate = 0.1f;
    private float fireTimer;

    [Header("��λ����")]
   [Tooltip("��װ�ӵ�����")] public KeyCode reloadInputName;


    [Header("UI����")] 
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
        Vector3 shootDirection = shooterPoint.forward;//���������
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
