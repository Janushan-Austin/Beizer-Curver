using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeizerCurves
{
    class Vec4
    {
        public double x, y, z, w;

        public Vec4()
        {
            x = y = z = 0;
            w = 1;
        }


        public Vec4(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
            w = 1;
        }

        public Vec4(Vec4 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
            w = vec.w;
        }

        public Vec4(System.Drawing.Color col)
        {
            x = col.R/255.0;
            y = col.G/255.0;
            z = col.B/255.0;
            w = col.A;
        }

        public static Vec4 operator *(Vec4 lhs, Vec4 rhs)
        {
            Vec4 ans = new Vec4(lhs);
            ans.x *= rhs.x;
            ans.y *= rhs.y;
            ans.z *= rhs.z;

            return ans;
        }

        public static Vec4 operator *(Vec4 lhs, double rhs)
        {
            Vec4 ans = new Vec4(lhs);
            ans.x *= rhs;
            ans.y *= rhs;
            ans.z *= rhs;

            return ans;
        }

        public static Vec4 operator *(double lhs, Vec4 rhs)
        {
            return rhs * lhs;
        }

        public static Vec4 operator +(Vec4 lhs, Vec4 rhs)
        {
            Vec4 ans = new Vec4(lhs);

            ans.x += rhs.x;
            ans.y += rhs.y;
            ans.z += rhs.z;

            return ans;
        }

        public double Dot(Vec4 vec)
        {
            return x * vec.x + y * vec.y + z * vec.z;
        }

        public static double Magnitude(Vec4 vec)
        {
            return Math.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
        }

        public static Vec4 Normal(Vec4 vec)
        {
            Vec4 result = new Vec4(vec);
            double magnitude = Magnitude(vec);

            result.x /= magnitude;
            result.y /= magnitude;
            result.z /= magnitude;

            return result;
        }
    }
}
