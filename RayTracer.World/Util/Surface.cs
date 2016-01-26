﻿using System;

namespace Raytracer.World.Util
{
    public class Surface
    {
        public Color Color { get; set; }
        public double RefractiveIndex { get; set; }
        public bool Glossy => Math.Abs(RefractiveIndex) < 1;

        public override string ToString()
        {
            return $"Surface[Diffuse={Color}, Reflection={RefractiveIndex}]";
        }
    }
}