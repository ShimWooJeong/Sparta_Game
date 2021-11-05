using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
	[Header("Camera")]
	public Camera TargetCamera;

	[Header("Axis")]
	public float MaxRange = 1f;

	[Header("Binding")]
	public UnityEvent<Vector2> JoystickValue;

	//
	protected Vector2 _neutralPosition;
	protected Vector2 _joystickValue;
	protected Vector2 _newTargetPosition;
	protected Vector3 _newJoystickPosition;

	protected virtual void Start()
	{
		Initialize();
	}

	protected virtual void OnEnable()
	{
		Initialize();
	}

	public virtual void Initialize()
	{
		_neutralPosition = GetComponent<RectTransform>().transform.position;
	}

	protected virtual void Update()
	{
		if (JoystickValue == null)
		{
			return;
		}

		// 입력값 가공
		_joystickValue.x = EvaluateInputValue(_newTargetPosition.x);
		_joystickValue.y = EvaluateInputValue(_newTargetPosition.y);

		JoystickValue.Invoke(_joystickValue);
	}

	//IDragHandler를 추가하면 반드시 OnDrag 함수를 포함해야 함
    //Drag를 하는 동안에 계속해서 호출되는 함수
	public virtual void OnDrag(PointerEventData eventData)
	{
		// 조이스틱 위치 조정
		_newTargetPosition = TargetCamera.ScreenToWorldPoint(eventData.position);
		_newTargetPosition = Vector2.ClampMagnitude(_newTargetPosition - _neutralPosition, MaxRange);
		_newJoystickPosition = _neutralPosition + _newTargetPosition;

		// 조이스틱 위치 수정
		transform.position = _newJoystickPosition;
		var localPos = transform.localPosition;
		transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);
	}

	//IEndDragHandler와 매치되는 함수
    //드래그가 끝날 때 호출되어 위치값, 조이스틱 값 초기화시켜주는 함수
	public virtual void OnEndDrag(PointerEventData eventData)
	{
		// 초기값으로 설정
		_newJoystickPosition = _neutralPosition;
		transform.position = _newJoystickPosition;
		var localPos = transform.localPosition;
		transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);

		_newTargetPosition = Vector2.zero;
		_joystickValue.x = 0f;
		_joystickValue.y = 0f;
	}

	protected virtual float EvaluateInputValue(float vectorPosition)
	{
		return Mathf.InverseLerp(0, MaxRange, Mathf.Abs(vectorPosition)) * Mathf.Sign(vectorPosition);
	}
}