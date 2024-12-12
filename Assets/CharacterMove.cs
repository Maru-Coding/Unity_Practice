using NUnit.Framework.Constraints;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
     // 움직이는 속도 제어
     public float speed = 10.0F;

     // 점프 높이 설정
     public float jumpSpeed = 8.0F;

     // 점프 후 바닥에 떨어지는 속도
     public float gravity = 20.0F;

     // 움직이는 방향 Vector3.zero = (0,0,0)
     private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
          // 인스펙터 뷰에서 변경할 수 있는 컨트롤러를 C#으로 가져옴
          CharacterController controller = GetComponent<CharacterController>();

          // 땅에 붙어있는지 확인
          if (controller.isGrounded)
          {
               // 키보드의 좌우 방향키
               float x = Input.GetAxis("Horizontal");

               // 키보드의 상하 방향키
               float z = Input.GetAxis("Vertical");

               // 키보드 방향키 입력을 Vector3으로 저장
               moveDirection = new Vector3(x, 0, z);

               // 좌표를 공간 월드 좌표로 변환
               moveDirection = transform.TransformDirection(moveDirection);

               // 움직임 속도 조정
               moveDirection *= speed;

               // 점프 버튼을 누르면 점프 (유니티 Edit - Project Settings - Input Manager에서 Axes - Jump - Positive Button에 스페이스바 버튼 입력)
               if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
          }
          
          // 착지하기
          moveDirection.y -= gravity * Time.deltaTime;

          // 캐릭터 이동하기
          controller.Move(moveDirection * Time.deltaTime);
    }
}
