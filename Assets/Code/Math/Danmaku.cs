using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Code {

    public static class Danmaku {

        public static IEnumerable <XY> Ring (XY dir, int bullets) {
            float step = 2 * Mathf.PI / bullets;
            for (int i = 0; i < bullets; i++) {
                yield return dir.Rotated (step * i);
            }
        }


        public static IEnumerable <XY> Cloud (float radius, int bullets) {
            for (int i = 0; i < bullets; i++) {
                yield return Cloud1 (radius);
            }
        }


        public static XY Cloud1 (float radius) {
            var   random = _.Random;
            float f      = 1 - random.Float () * random.Float () * random.Float ();
            return f * radius * new XY (random.Angle ());
        }


        public static IEnumerable <XY> Spray (XY dir, float cone, int bullets) {
            if (bullets == 1) {
                yield return dir;
                yield break;
            }
            float step = cone / (bullets - 1);
            float half = cone * 0.5f;
            for (int i = 0; i < bullets; i++) {
                yield return dir.Rotated (step * i - half);
            }
        }


        public static IEnumerable <XY> Line (XY dir, float minCoeff, float maxCoeff, int bullets) {
            float div = bullets - 1;
            for (int i = 0; i < bullets; i++) {
                yield return dir * Mathf.LerpUnclamped (minCoeff, maxCoeff, i / div);
            }
        }


        public static IEnumerable <XY> Shotgun (XY dir, float cone, float minCoeff, float maxCoeff, int bullets) {
            for (int i = 0; i < bullets; i++) {
                yield return Shotgun1 (dir, cone, minCoeff, maxCoeff);
            }
        }


        public static XY Shotgun1 (XY dir, float cone, float minCoeff, float maxCoeff) {
            dir.Rotate (cone * _.Random.SignedFloat ());
            return dir * Mathf.LerpUnclamped (minCoeff, maxCoeff, _.Random.Float ());
        }


        public static XY FarFrom (IEnumerable <XY> existing, Func <XY> generator, int rolls = 2) {
            return FarFrom (existing, generator, XY.SqrDistance, rolls);
        }


        public static T FarFrom <T> (
            IEnumerable <T> existing,
            Func <T> generator,
            Func <T, T, float> distance,
            int rolls = 2
        ) {
            var maxT = generator ();

            if (!existing.Any ()) return maxT;

            float minD = float.NaN;
            foreach (var e in existing) {
                float d = distance (maxT, e);
                if (d >= minD) continue;
                minD = d;
            }
            float maxD = minD;

            for (int i = 1; i < rolls; i++) {
                var t = generator ();
                minD = float.NaN;
                foreach (var e in existing) {
                    float d = distance (t, e);
                    if (d >= minD) continue;
                    minD = d;
                }
                if (minD <= maxD) continue;
                maxD = minD;
                maxT = t;
            }
            return maxT;
        }

    }

}