using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyDeviation : MonoBehaviour
{
    private KoEnemyManager enemyManager;

    //�w�b�h�̉�]���x
    [SerializeField]
    private float m_rotateSpeed = 30.0f;
    //�e�̃v���n�u
    [SerializeField]
    private GameObject m_bulletPrefab = null;
    //�e�̔��ˈʒu
    [SerializeField]
    private Transform m_cannonTips = null;
    //�e�̔��ˑ��x
    [SerializeField]
    private float m_bulletSpeed = 3.0f;
    //����
    [SerializeField]
    private float m_recoilTime = 1.0f;
    private float m_recoil = 0.0f;
    //�e�̔��˕p�x
    [SerializeField]
    private float m_intervalTime = 5.0f;
    private float m_interval;

    //�^�[�Q�b�g
    [SerializeField]
    private GameObject target;

    Vector3 targetPrePosition;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<KoEnemyManager>();
        enemyManager.AddEnemy(gameObject);
        m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f);
    }

    public Vector3 LinePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,float bulletSpeed)
    {
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;

        //�^�[�Q�b�g�̈ړ�����
        Vector3 targetMove = targetPosition - targetPrePosition;
        //�^�[�Q�b�g�̈ړ���
        float targetSpeed = (targetPosition - targetPrePosition).magnitude;

        //�ˌ��ʒu����^�[�Q�b�g�̌��݈ʒu�܂ł̃x�N�g��
        Vector3 vec = targetPosition - shotPosition;

        float frame=0.0f;
        //�^�[�Q�b�g������������Ɖ��肵�Č��݂̈ʒu��1�t���[�����̈ړ��ʂ���e���^�[�Q�b�g�ɒǂ����܂ł̎��Ԃ��Z�o
        if(targetSpeed!=bulletSpeed)
        {
            frame =Mathf.Abs((vec.magnitude) / (targetSpeed - bulletSpeed));
        }

        Vector3 predictionPos = shotPosition+vec + targetMove * frame;

        return predictionPos;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        Vector3 targetPosition=target.transform.position;

        ////�e���������������Ȃ����
        if (m_recoil < 0)
        {
            targetPosition = LinePrediction(transform.position, target.transform.position, targetPrePosition, m_bulletSpeed);
            targetPrePosition = target.transform.position;

            //�v���C���[�܂ł̃x�N�g�����Z�o
            Vector3 forward = targetPosition - transform.parent.position;
            //Lerp�֐��ŏ��X�ɗ\���ʒu�̕����Ɍ���
            transform.forward += forward * m_rotateSpeed * Time.deltaTime;
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
                bulletrb.AddForce((targetPosition-transform.position).normalized*m_bulletSpeed,ForceMode.VelocityChange);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f);
        }
    }

    private void OnDestroy()
    {
        if (enemyManager != null)
        {
            enemyManager.RemoveEnemy(gameObject);
        }

        GameObject body = transform.parent.gameObject;
        Destroy(body);
    }
}
