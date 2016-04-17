using System.Collections;
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
    private Form m_CurrentForm = Form.HUMAN;
    private Form m_PreviousForm;
    private bool m_IsTransforming;

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

        ChangeForm(Form.HUMAN);
	}
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1) && m_Platformer.isGrounded()) {
            ChangeForm(Form.HUMAN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && m_Platformer.isGrounded()) {
            ChangeForm(Form.BIRD);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && m_Platformer.isGrounded()) {
            ChangeForm(Form.BEAR);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && m_Platformer.isGrounded()) {
            ChangeForm(Form.FOX);
        }        
    }

    private void ChangeForm(Form newForm) {
        if (m_IsTransforming) return;

        m_PreviousForm = m_CurrentForm;
        m_CurrentForm = newForm;
        switch (m_CurrentForm) {
            case Form.HUMAN:
                m_Platformer.setMaxSpeed(m_HumanMaxSpeed);
                m_Platformer.setJumpForce(m_HumanJumpForce);
                m_Platformer.setCanFly(false);
                m_Rigidbody.gravityScale = 2.5f;
                break;
            case Form.BIRD:
                m_Platformer.setMaxSpeed(m_BirdMaxSpeed);
                m_Platformer.setJumpForce(m_BirdJumpForce);
                m_Platformer.setCanFly(true);
                m_Rigidbody.gravityScale = 1f;
                break;
            case Form.BEAR:
                m_Platformer.setMaxSpeed(m_BearMaxSpeed);
                m_Platformer.setJumpForce(m_BearJumpForce);
                m_Platformer.setCanFly(false);
                m_Rigidbody.gravityScale = 2.5f;
                break;
            case Form.FOX:
                m_Platformer.setMaxSpeed(m_FoxMaxSpeed);
                m_Platformer.setJumpForce(m_FoxJumpForce);
                m_Platformer.setCanFly(false);
                m_Rigidbody.gravityScale = 2.5f;
                break;
        }

        if (m_CurrentForm != m_PreviousForm) {
            m_Animator.SetFloat("Speed", 0f);
            m_Animator.SetInteger("Form", (int)m_CurrentForm);
            SpawnTransformEffect();
            StartCoroutine(TransfromCooldown());
        }
    }

    private void SpawnTransformEffect() {
        GameObject transformEffect = Instantiate(m_TransformEffectPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(transformEffect, 3f);
    }

    private IEnumerator TransfromCooldown() {
        m_IsTransforming = true;
        yield return new WaitForSeconds(1f);
        m_IsTransforming = false;
    }
}
