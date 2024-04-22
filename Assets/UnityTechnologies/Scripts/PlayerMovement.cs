using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* 
     * 계원예술대학교 게임미디어과 3D프로그래밍 중간고사
     * 총 문제 : 5문제(50점) + 동작 확인(50점)
     * 
     * 현재 이 프로젝트는 바로 실행하면 에러가 발생합니다.
     * 오류 없이 [수업 시간에 구현한 만큼 동작]하게 하는 것이 목적입니다.
     * 
     * 스크립트를 올바르게 작성해도 동작이 완벽하지 않습니다.
     * 해당 부분까지 완벽하게 구현이 끝나야 만점으로 인정합니다.
     */

    [Header("회전 스피드")]
    public float turnSpeed = 20f;

    // 문제 1에서 사용해야 할 변수들
    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    private void Start()
    {        
        // 문제 1) 위에 주어진 animator, rb 변수를 이용해 Component를 받아오는 명령어를 작성하세요.
        // (Component당 5점, 합계 5*2=10점, 부분점수 있음)

    }

    private void FixedUpdate()
    {
        // 문제 2) Input.GetAxis를 사용하여 존 레몬이 움직일 수 있게 좌표를 입력하세요.
        // 0f 대신 정답을 채워넣으면 작동합니다. (각 변수당 5점, 총 10점)
        float horizontal = 0f; // 이 변수와
        float vertical = 0f; // 이 변수를 사용해야 합니다.
        
        #region 건드리면 작동 안 됨
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();
        #endregion

        // 문제 3) isWalking은 hasHorizontalInput과 hasVerticalInput중 하나만 입력되어도 true(참)가 되어야 합니다.
        // false를 지우고 제대로 된 명령줄을 완성해 주세요. (10점)
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);        

        bool isWalking = false;

        // 문제 4) isWalking 변수를 Animator의 IsWalking 파라미터에 적용하세요. (10점)


        // 문제 5) 원하는 방향으로 이동할 수 있는 Vector3값을 만드는 명령줄을 Vector3.zero를 지우고 완성해 주세요. (10점)
        Vector3 desiredFoward = Vector3.zero;
        rotation = Quaternion.LookRotation(desiredFoward);

    }

    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}
