using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject target; // �^�[�Q�b�g�ւ̎Q��
    public float speed = 5f; // ��]���x

    void Start()
    {
        if (target == null)
        {
            // �^�[�Q�b�g���w�肳��Ă��Ȃ��ꍇ�́A�������g���^�[�Q�b�g�ɂ���
            target = this.gameObject;
        }
    }

    void Update()
    {
        // �^�[�Q�b�g�̎������]����
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
