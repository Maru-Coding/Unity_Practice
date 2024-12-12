using NUnit.Framework.Constraints;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
     // �����̴� �ӵ� ����
     public float speed = 10.0F;

     // ���� ���� ����
     public float jumpSpeed = 8.0F;

     // ���� �� �ٴڿ� �������� �ӵ�
     public float gravity = 20.0F;

     // �����̴� ���� Vector3.zero = (0,0,0)
     private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
          // �ν����� �信�� ������ �� �ִ� ��Ʈ�ѷ��� C#���� ������
          CharacterController controller = GetComponent<CharacterController>();

          // ���� �پ��ִ��� Ȯ��
          if (controller.isGrounded)
          {
               // Ű������ �¿� ����Ű
               float x = Input.GetAxis("Horizontal");

               // Ű������ ���� ����Ű
               float z = Input.GetAxis("Vertical");

               // Ű���� ����Ű �Է��� Vector3���� ����
               moveDirection = new Vector3(x, 0, z);

               // ��ǥ�� ���� ���� ��ǥ�� ��ȯ
               moveDirection = transform.TransformDirection(moveDirection);

               // ������ �ӵ� ����
               moveDirection *= speed;

               // ���� ��ư�� ������ ���� (����Ƽ Edit - Project Settings - Input Manager���� Axes - Jump - Positive Button�� �����̽��� ��ư �Է�)
               if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
          }
          
          // �����ϱ�
          moveDirection.y -= gravity * Time.deltaTime;

          // ĳ���� �̵��ϱ�
          controller.Move(moveDirection * Time.deltaTime);
    }
}
