using UnityEngine;

public class MoveObject : MonoBehaviour
{
     float speed = 20F;

    void Start()
    {
          
     }

    void Update()
    {
          // Ű���� �Է��� ���� �� �ִ� �޼���
          // Vertical�� ��� ��,�Ʒ� ����Ű
          // Horizontal�� ��� ��,���� ����Ű
          float position1 = Input.GetAxis("Vertical");
          float position2 = Input.GetAxis("Horizontal");

          // ��ġ =     ��ġ * �̵��ӵ� * ������ ���� �ð�
          position1 = position1 * speed * Time.deltaTime;
          position2 = position2 * speed * Time.deltaTime;

          // ������Ʈ ��ġ ����(��,��)
          transform.Translate(Vector3.forward * position1);

          // ������Ʈ ��ġ ����(��,��)
          transform.Translate(Vector3.right * position2);
     }
}
