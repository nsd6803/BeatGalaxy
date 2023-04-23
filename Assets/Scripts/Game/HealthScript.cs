using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int health; // начальное значение здоровь€
    public int damageAmount; // количество урона

    public void Damage(int damageAmount)
    {
        health -= damageAmount; // вычитаем количество урона из здоровь€
        if (health <= 0)
        {
            Die(); // если здоровье меньше или равно нулю, умереть
        }
    }

    private void Die()
    {
        // ƒополнительные действи€ при смерти объекта, если нужно
        Destroy(gameObject); // уничтожить объект
    }

    void OnCollisionEnter2D(Collision2D other)
    {

       
    }
}