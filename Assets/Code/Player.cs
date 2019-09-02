using Code.Core;
using Code.Math;
using UnityEngine;
using ParticleHandler = Code.Systems.ParticleSystem.ParticleHandler;


namespace Code {

    public class Player : Entity {

        private ParticleHandler particleHandler;
        public XY P { get; private set; }


        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
            particleHandler = _.Game.ParticleSystem.Add (UpdateParticle);
        }


        private void UpdateParticle (ref ParticleSystem.Particle particle) {
            particle.position = (Vector3) P;
            particle.startSize = 30;
            particle.startColor = Color.green;
        }


        protected override void OnUpdate () {
            var v = XY.Zero;
            if (Input.GetKey (KeyCode.LeftArrow)) v.X--;
            if (Input.GetKey (KeyCode.RightArrow)) v.X++;
            if (Input.GetKey (KeyCode.DownArrow)) v.Y--;
            if (Input.GetKey (KeyCode.UpArrow)) v.Y++;
            P += v * 5;
        }


        protected override void OnDespawn () {
            particleHandler.Alive = false;
        }

    }

}
