using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyDeviation : MonoBehaviour
{
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
    private float m_pow = 3.0f;
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
    Vector3 targetPrePosition2;

    public Vector3 LinePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,float bulletSpeed)
    {
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;
        //�W�I��1�t���[���̈ړ����x
        Vector3 targetSpeed = targetPosition - targetPrePosition;
        //�ˌ��ʒu���猩���W�I�̈ʒu
        Vector3 targetVec = targetPosition - shotPosition;

        float A = Vector3.SqrMagnitude(targetSpeed) - bulletSpeed * bulletSpeed;
        float B = Vector3.Dot(targetVec, targetSpeed);
        float C = Vector3.SqrMagnitude(targetVec);

        //0���֎~
        if (A == 0 && B == 0) return targetPosition;
        if (A == 0) return targetPosition + targetSpeed * (-C / B / 2);

        float D = Mathf.Sqrt(Mathf.Abs(B * B - A * C));
        return targetPosition + targetSpeed * PlusMin((-B-D)/A,(-B+D)/A);
    }

    public float PlusMin(float a, float b)
    {
        if (a < 0 && b < 0) return 0;
        if (a < 0) return b;
        if (b < 0) return a;
        return a < b ? a : b;
    }

    public Vector3 CirclePrediction(Vector3 shotPosition,Vector3 targetPosition,Vector3 targetPrePosition,Vector3 targetPrePosition2,float bulletSpeed)
    {
        //3�_�̊p�x�ω����������ꍇ�͐��`�\���ɐ؂�ւ�
        if(Mathf.Abs(Vector3.Angle(targetPosition-targetPrePosition,targetPrePosition-targetPrePosition2))<0.03)
        {
            return LinePrediction(shotPosition, targetPosition, targetPosition,bulletSpeed);
        }

        //Unity�̕�����m/s�Ȃ̂�m/flame�ɂ���
        bulletSpeed = bulletSpeed * Time.fixedDeltaTime;

        //3�_����~�̒��S�_(�O�p�`�̊O�S)���o��
        Vector3 CenterPosition = Circumcenter(targetPosition, targetPrePosition, targetPrePosition2);

        //���S�_���猩��1�t���[���̊p���x�Ǝ����o��
        Vector3 axis = Vector3.Cross(targetPrePosition - CenterPosition, targetPosition - CenterPosition);
        float angle = Vector3.Angle(targetPrePosition - CenterPosition, targetPosition - CenterPosition);

        //���݈ʒu�ł̒e�̓��B���Ԃ��o��
        float PredictionFlame = Vector3.Distance(targetPosition, shotPosition) / bulletSpeed;
    
        //���B���ԕ����ړ������\���ʒu�ōČv�Z���ē��B���Ԃ�␳����
        for(int i=0;i<3;++i)
        {
            PredictionFlame = Vector3.Distance(RotateToPosition(targetPosition, CenterPosition, axis, angle * PredictionFlame), shotPosition/bulletSpeed);
        }
        return RotateToPosition(targetPosition, CenterPosition, axis, angle * PredictionFlame);
    }

    //�O�p�`�̒��_�A�O�_�̈ʒu����O�S�̈ʒu��Ԃ�
    public Vector3 Circumcenter(Vector3 posA,Vector3 posB,Vector3 posC)
    {
        //�O�ӂ̒����̓����o��
        float edgeA = Vector3.SqrMagnitude(posB - posC);
        float edgeB = Vector3.SqrMagnitude(posC - posA);
        float edgeC = Vector3.SqrMagnitude(posA - posB);

        //�d�S���W�n�Ōv�Z����
        float a = edgeA * (-edgeA + edgeB + edgeC);
        float b = edgeB * (edgeA - edgeB + edgeC);
        float c = edgeC * (edgeA + edgeB - edgeC);

        if (a + b + c == 0) return (posA + posB + posC) / 3;
        return (posA * a + posB * b + posC * c) / (a + b + c);
    }

    //�ڕW�ʒu���Z���^�[�ʒu�Ŏ��Ɗp�x�ŉ�]�������ʒu��Ԃ�
    public Vector3 RotateToPosition(Vector3 v3_target,Vector3 v3_center,Vector3 v3_axis,float f_angle)
    {
        return Quaternion.AngleAxis(f_angle, v3_axis) * (v3_target - v3_center) + v3_center;
    }

    private void Update()
    {
        m_recoil -= Time.deltaTime;
        m_interval -= Time.deltaTime;

        Vector3 targetPosition;

        ////�e���������������Ȃ����
        //if (m_recoil < 0)
        {
            targetPosition = CirclePrediction(transform.position, target.transform.position, targetPrePosition, targetPrePosition2, m_pow);
            targetPrePosition2 = targetPrePosition;
            targetPrePosition = target.transform.position;

            //�v���C���[�܂ł̃x�N�g�����Z�o
            Vector3 forward = targetPosition - transform.parent.position;
            forward.y = 0;
            //forward.Normalize();
            //Lerp�֐��ŏ��X�ɗ\���ʒu�̕����Ɍ���
            transform.forward += forward * Time.deltaTime; //* m_rotateSpeed * Time.deltaTime;
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
                bulletrb.AddForce((targetPosition-transform.position).normalized*m_pow,ForceMode.VelocityChange);
            }
            m_recoil = m_recoilTime;
            m_interval = m_intervalTime + Random.Range(-1.0f, 1.0f); ;
        }
    }
}
