using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private bool _isAttacking=false;
	private Animator _animator;
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_animator = GetComponentInChildren<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
		// Wanna Attack?
		if (Input.GetButtonDown("Fire1")  && _isAttacking == false)
		{
			_rigidbody.velocity = Vector2.zero;
			_animator.SetTrigger("Attacking");
		}

		// Animator
		if ((_animator.GetCurrentAnimatorClipInfo(0))[0].clip.name == "Attacking")
		{
			_isAttacking = true;
			print(_isAttacking);
		}
		else
		{
			_isAttacking = false;
		}
	}

	
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (_isAttacking) {
			if (collision.CompareTag("Enemy") ) {
				collision.GetComponent<Enemy>().ReproducirExplosion();
				Destroy(collision.transform.parent.gameObject);
			}
		}
	}
}
