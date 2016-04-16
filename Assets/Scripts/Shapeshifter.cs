using UnityEngine;

public class Shapeshifter : MonoBehaviour {
    private Animator m_Animator;

	void Start () {
        m_Animator = GetComponent<Animator>();
	}
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1)) {
            m_Animator.SetInteger("Form", 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            m_Animator.SetInteger("Form", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            m_Animator.SetInteger("Form", 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            m_Animator.SetInteger("Form", 3);
        }
    }
}
