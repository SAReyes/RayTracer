﻿using System;
using Raytracer.World.Space;

namespace Raytracer.World
{
    public class Camera
    {
        public Point Position { get; set; }
        public double F { get; set; }
        private Viewport _viewport { get; set; }

        public Viewport Viewport
        {
            get
            {
                return _viewport;
            }
            set
            {
                _viewport = value;

                _l = value.Width / 2.0;
                _t = value.Height / 2.0;

                _du = value.Width / (double)(value.Width - 1);
                _dv = value.Height / (double)(value.Height - 1);
            }
        }

        public Vector U { get; }
        public Vector V { get; }
        public Vector W { get; }

        private double _l;
        private double _t;

        private double _du;
        private double _dv;

        public Camera(Point position, double f, Viewport viewport, Vector g) : this(position, g)
        {
            F = f;
            Viewport = viewport;
        }

        public Camera(Point position, Vector g)
        {
            F = 100;
            Viewport = new Viewport(800, 600);

            Position = position;

            W = -g.Normalize();

            var Up = new Vector(0, 1, 0);

            U = Up.Cross(W).Normalize();
            V = W.Cross(U);

        }

        /// <summary>
        /// Retrieves a Pixel in the camera world reference
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public Point Pixel(double i, double j)
        {
            return new Point(-_l + j * _du, _t - i * _dv, -F);
        }

        public Ray WorldRay(double i, double j)
        {
            return new Ray
            {
                Origin = Position,
                Direction = Pixel(i, j).Transform(TranformationMatrix()) - Position
            };
        }

        public Matrix TranformationMatrix()
        {
            var matrix = new Matrix(4, 4)
            {
                [0] = U.Array(),
                [1] = V.Array(),
                [2] = W.Array(),
                [3] = Position.Array()
            };
            return matrix;
        }

        public override string ToString()
        {
            return $"Camera=[Position={Position}, Viewport={Viewport}, F={F}, U={U}, V={V}, W={W}]";
        }

        private Point DisplacementArray()
        {
            return new Point(Position.X, Position.Y, -Position.Z);
        }

    }
}