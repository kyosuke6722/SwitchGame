using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyHead : MonoBehaviour
{
    //�w�b�h�̉�]���x
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //�e�̃v���n�u
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //�e�̔��ˈʒu
    [SerializeField]
    private Transform m_cannonTips=null;
    //�e�̔��ˑ��x
    [SerializeField]
    private float m_bulletSpeed = 3.0f;
    //����
    [SerializeField]
    private float m_recoilTime=1.0f;
    private float m_recoil=0.0f;
    //�e�̔��˕p�x
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval;

    //�^�[�Q�b�g
    [SerializeField]
    private GameObject target;

    private void Start()
    {
        m_interval = m_intervalTime+Random.Range(-1.0f,1.0f);
    }

    void Update()
    {
        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        //�e���������������Ȃ����
        if (m_recoil<0)
        {
            LockOn();
        }

        if (m_interval < 0)
        {
            GameObject BulletObj = Instantiate
                (m_bulletPrefab,
                m_cannonTips.position,
                this.transform.rotation);

            //�e��Rigidbody���擾
            Rigidbody bulletrb = BulletObj.GetComponent<Rigidbody>();
            if (bulletrb != null)
            {
                //�e����
                bulletrb.AddForce(transform.forward*m_bulletSpeed, ForceMode.Impulse);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f); ;
        }
    }

    public void LockOn()
    {
        //�v���C���[�܂ł̃x�N�g�����Z�o
        Vector3 lookAtPos = target.transform.position;
        Vector3 forward = lookAtPos - transform.parent.position;
        forward.y = 0;
        forward.Normalize();
        //Lerp�֐��ŏ��X�Ƀv���C���[�̕����Ɍ���
        transform.forward += forward * m_rotateSpeed * Time.deltaTime; ;
    }
}
