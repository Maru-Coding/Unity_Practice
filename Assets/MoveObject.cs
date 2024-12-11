using UnityEngine;

public class MoveObject : MonoBehaviour
{
     float speed = 20F;

    void Start()
    {
          
     }

    void Update()
    {
          // 키보드 입력을 받을 수 있는 메서드
          // Vertical일 경우 위,아래 방향키
          // Horizontal일 경우 왼,오른 방향키
          float position1 = Input.GetAxis("Vertical");
          float position2 = Input.GetAxis("Horizontal");

          // 위치 =     위치 * 이동속도 * 프레임 간격 시간
          position1 = position1 * speed * Time.deltaTime;
          position2 = position2 * speed * Time.deltaTime;

          // 오브젝트 위치 변경(앞,뒤)
          transform.Translate(Vector3.forward * position1);

          // 오브젝트 위치 변경(좌,우)
          transform.Translate(Vector3.right * position2);
     }
}
