using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeizerCurves
{
    class Vec4
    {
        public double[] Vector;

        public Vec4()
        {
            Vector = new double[4];
            for(int i=0; i<4; i++)
            {
                Vector[i] = 0;
            }
        }


        public static Vec4 operator *(Vec4 lhs, double rhs)
        {
            Vec4 ans = new Vec4();
            for(int i=0; i<4; i++)
            {
                ans.Vector[i] = lhs.Vector[i] * rhs;
            }

            return ans;
        }
    }
}
