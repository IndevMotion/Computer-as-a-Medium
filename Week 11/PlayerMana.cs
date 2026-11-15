using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMana : MonoBehaviour
{
    public int mana = 100;
    public TMP_Text manaText;
    public Animator animator;

    void Start()
    {
        manaText.text = "Mana: " + mana;
    }

    void Update()
    {
        UseMana();
        manaText.text = "Mana: " + mana;
    }

    void UseMana()
    {
        // wasPressedThisFrame = only fires once per key press
        if (Keyboard.current.rKey.wasPressedThisFrame && mana >= 10)
        {
            mana -= 10;
            animator.SetTrigger("ManaUse");
        }
    }
}