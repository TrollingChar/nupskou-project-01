using UnityEngine;
using ParticleHandler = Code.ParticleSystem.ParticleHandler;


namespace Code {

    public class Bullet : Entity {

        private readonly XY              p0, v;
        private          ParticleHandler particleHandler;


        public Bullet (XY p0, XY v) {
            this.p0 = p0;
            this.v  = v;
        }


        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
            particleHandler = _.Game.RoundBulletSystem.Add (UpdateParticle);
        }


        private void UpdateParticle (ref UnityEngine.ParticleSystem.Particle particle) {
            particle.position   = (Vector3) (p0 + v * Age);
            particle.startSize  = 15;
            particle.startColor = Color.red;
        }


        protected override void OnUpdate () {
            if (Age == Utils.Time (5, 00)) Despawn ();
        }


        protected override void OnDespawn () {
            particleHandler.Alive = false;
        }

    }

}
