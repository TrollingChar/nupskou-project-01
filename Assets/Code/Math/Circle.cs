﻿namespace Code {

    public struct Circle {

        public XY    Center;
        public float Radius;


        public float X {
            get { return Center.X; }
            set { Center.X = value; }
        }


        public float Y {
            get { return Center.Y; }
            set { Center.Y = value; }
        }
        

        public Circle (XY o, float r) {
            Center = o;
            Radius = r;
        }


        public Circle (float x, float y, float r) : this (new XY (x, y), r) {}
        
        
        public override string ToString ()              => $"({Center}, {Radius:F1})";
        public          string ToString (string format) => $"({Center.ToString (format)}, {Radius.ToString (format)})";

    }

}