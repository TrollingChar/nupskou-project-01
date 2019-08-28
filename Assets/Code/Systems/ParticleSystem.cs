using UnityEngine;


namespace Code.Systems {

    // сделаем здесь то же что и в тп4: для каждого вида частиц своя система
    // меняться будет цвет частицы, размер, положение и т.д.
    public class ParticleSystem : MonoBehaviour {

        [SerializeField] private new UnityEngine.ParticleSystem particleSystem;

    }

}
