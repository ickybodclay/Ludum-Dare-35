using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Shapeshifter : MonoBehaviour {
    public enum Form {
        HUMAN = 0,
        BIRD,
        BEAR,
        FOX
    }

    private PlatformerCharacter2D m_Platformer;
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    private Form m_CurrentForm;
    private Form m_PreviousForm;

    public GameObject m_TransformEffectPrefab;

    public float m_HumanMaxSpeed;
    public float m_HumanJumpForce;
    public float m_BirdMaxSpeed;
    public float m_BirdJumpForce;
    public float m_BearMaxSpeed;
    public float m_BearJumpForce;
    public float m_FoxMaxSpeed;
    public float m_FoxJumpForce;

	void Start () {
        m_Platformer = GetComponent<PlatformerCharacter2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();

        m_CurrentForm = Form.HUMAN;
	}
	
	void Update () {
        m_PreviousForm = m_CurrentForm;
	    if (Input.GetKeyDown(KeyCode.Alpha1) && m_Platformer.isGrounded()) {
            m_CurrentForm = Form.HUMAN;
            m_Platformer.setMaxSpeed(m_HumanMaxSpeed);
            m_Platformer.setJumpForce(m_HumanJumpForce);
            m_Platformer.setCanFly(false);
            m_Rigidbody.gravityScale = 2.5f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && m_Platformer.isGrounded()) {
            m_CurrentForm = Form.BIRD;
            m_Platformer.setMaxSpeed(m_BirdMaxSpeed);
            m_Platformer.setJumpForce(m_BirdJumpForce);
            m_Platformer.setCanFly(true);
            m_Rigidbody.gravityScale = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && m_Platformer.isGrounded()) {
            m_CurrentForm = Form.BEAR;
            m_Platformer.setMaxSpeed(m_BearMaxSpeed);
            m_Platformer.setJumpForce(m_BearJumpForce);
            m_Platformer.setCanFly(false);
            m_Rigidbody.gravityScale = 2.5f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && m_Platformer.isGrounded()) {
            m_CurrentForm = Form.FOX;
            m_Platformer.setMaxSpeed(m_FoxMaxSpeed);
            m_Platformer.setJumpForce(m_FoxJumpForce);
            m_Platformer.setCanFly(false);
            m_Rigidbody.gravityScale = 2.5f;
        }

        if (m_CurrentForm != m_PreviousForm) {
            m_Animator.SetInteger("Form", (int)m_CurrentForm);
            SpawnTransformEffect();
        }
    }

    private void SpawnTransformEffect() {
        GameObject transformEffect = Instantiate(m_TransformEffectPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(transformEffect, 3f);
    }
}
