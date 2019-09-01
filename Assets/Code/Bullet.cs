using Code.Core;
using UnityEngine;
using ParticleHandler = Code.Systems.ParticleSystem.ParticleHandler;
using static Code.Utils.Utils;


namespace Code {

    public class Bullet : Entity {

        private readonly Vector2 p0, v;
        private ParticleHandler particleHandler;


        public Bullet (Vector2 p0, Vector2 v) {
            this.p0 = p0;
            this.v  = v;
        }


        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
            particleHandler = _.Game.ParticleSystem.Add (UpdateParticle);
        }


        private void UpdateParticle (ref ParticleSystem.Particle particle) {
            particle.position = p0 + v * Age;
            particle.startSize = 40;
            particle.startColor = Color.red;
        }


        protected override void OnUpdate () {
            if (Age == Time (3, 00)) Despawn ();
        }


        protected override void OnDespawn () {
            particleHandler.Alive = false;
        }

    }

}