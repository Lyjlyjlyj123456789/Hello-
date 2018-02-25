using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float zDistance = 5f;
	public float yHeight = 2f;

	public float zDamping = 2f;
	public float yDamping = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		float currentY = transform.position.y;
		float targetY = target.position.y + yHeight;
		float y = Mathf.Lerp (currentY,targetY,yDamping*Time.deltaTime);

		float currentRotationY = transform.eulerAngles.y;
		float targetRotationY = target.eulerAngles.y;
		float yAngel = Mathf.LerpAngle (currentRotationY,targetRotationY,3f*Time.deltaTime);

		transform.position = target.position;//(x,0,z)

		//四元数*向量(向量长度就是半径)  能够表示一个圆弧上的坐标位置
		transform.position -= Quaternion.Euler (0,yAngel,0) * Vector3.forward * zDistance;

		transform.position = new Vector3(transform.position.x,y,transform.position.z);
		//LookAt能够改变相机旋转角度达到一直观看着某个坐标位置不变
		transform.LookAt(target);
	}
}
