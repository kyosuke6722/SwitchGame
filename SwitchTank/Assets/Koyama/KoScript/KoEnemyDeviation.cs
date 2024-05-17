using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoEnemyDeviation : KoEnemyHead
{
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

    public float PlusMin(float a,float b)
    {
        if (a < 0 && b < 0) return 0;
        if (a < 0) return b;
        if (b < 0) return a;
        return a < b ? a : b;
    }

    public override void LockOn()
    {
        
    }
}
