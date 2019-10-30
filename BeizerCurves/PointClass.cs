using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BeizerCurves
{
    class PointClass
    {
        public double x;
        public double y;
        public double z;
        public Color PointColor;
        public double PointSize;

        public int Dimension;

        public PointClass(double _x = 0, double _y = 0, double _z = 0, Color color = default(Color) , double size = 1, int dimension = 3)
        {
            x = _x;
            y = _y;
            z = _z;
            PointColor = color;

            if(size < 0)
            {
                size = 0;
            }
            PointSize = size;

            Dimension = dimension;
        }

        public PointClass(PointClass cpy)
        {
            x = cpy.x;
            y = cpy.y;
            z = cpy.z;
            Dimension = cpy.Dimension;
            PointColor = cpy.PointColor;
        }

        public void SetComponent(int component, double value)
        {
            switch (component)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                case 2:
                    z = value;
                    break;
                default:
                    MessageBox.Show("Invalid component index: Set");
                    break;
            }
        }

        public double GetComponent(int component)
        {
            double value = new double();
            switch (component)
            {
                case 0:
                    value = x;
                    break;
                case 1:
                    value = y;
                    break;
                case 2:
                    value = z;
                    break;
                default:
                    MessageBox.Show("Invalid component index: Get");
                    break;
            }

            return value;
        }


        public static PointClass operator +(PointClass lhs, PointClass rhs)
        {
            PointClass value = new PointClass(lhs);

            value.x += rhs.x;
            value.y += rhs.y;
            value.z += rhs.z;

            return value;
        }

        public static PointClass operator -(PointClass lhs, PointClass rhs)
        {
            PointClass value = new PointClass(lhs);

            value.x -= rhs.x;
            value.y -= rhs.y;
            value.z -= rhs.z;

            return value;
        }

        public override string ToString()
        {
            return "(" + Math.Round(x,2).ToString() + ", " + Math.Round(y, 2).ToString() + ", " + Math.Round(z, 2).ToString() + ")"; 
        }
    }
}
