using UnityEngine;

public class Shapeshifter : MonoBehaviour {
    public enum Form {
        HUMAN = 0,
        BIRD,
        BEAR,
        FOX
    }

    private Animator m_Animator;
    private Form m_CurrentForm;

	void Start () {
        m_Animator = GetComponent<Animator>();

        m_CurrentForm = Form.HUMAN;
	}
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1)) {
            m_CurrentForm = Form.HUMAN;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            m_CurrentForm = Form.BIRD;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            m_CurrentForm = Form.BEAR;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            m_CurrentForm = Form.FOX;
        }

        m_Animator.SetInteger("Form", (int)m_CurrentForm);
    }
}
