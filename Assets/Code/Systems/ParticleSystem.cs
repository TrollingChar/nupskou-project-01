using UnityEngine;
using Ups = UnityEngine.ParticleSystem;


namespace Code.Systems {

    // сделаем здесь то же что и в тп4: для каждого вида частиц своя система
    // меняться будет цвет частицы, размер, положение и т.д.
    public class ParticleSystem : MonoBehaviour {

        public delegate bool UpdateParticle (ref Ups.Particle particle); // false если частица удалена


        [SerializeField] private Ups unityParticleSystem;


        public void Work () {}


        public void AddParticle (UpdateParticle handler) {}

    }

}
