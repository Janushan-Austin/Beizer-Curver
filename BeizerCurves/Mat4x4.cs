using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeizerCurves
{
    class Mat4x4
    {
        double[][] Mat;

        public Mat4x4()
        {
            Mat = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                Mat[i] = new double[4];
                for (int j = 0; j < 4; j++)
                {
                    Mat[i][j] = 0;
                }
                Mat[i][i] = 1;
            }
        }

        public Mat4x4(double[][] mat)
        {
            if (mat.Length != 4)
            {
                Mat4x4 tmp = new Mat4x4();
                Mat = tmp.Mat;
            }
            for (int i = 0; i < 4; i++)
            {
                if (mat[i].Length != 4)
                {
                    Mat4x4 tmp = new Mat4x4();
                    Mat = tmp.Mat;
                    break;
                }
                for (int j = 0; j < 4; j++)
                {
                    Mat[i][j] = mat[i][j];
                }
            }
        }

        public Mat4x4(Mat4x4 mat)
        {
            if (mat != null)
            {
                Mat = mat.Mat;
            }
        }

        public Mat4x4 MakePerspective(double fov, double aspectRatio, double near, double far)
        {
            double fovRad = 1 / (Math.Tan(fov * 0.5 * Math.PI / 180.0));
            Mat4x4 mat = new Mat4x4();
            mat.Mat[0][0] = aspectRatio * fovRad;
            mat.Mat[1][1] = fovRad;
            mat.Mat[2][2] = far / (far - near);
            mat.Mat[3][2] = -near * mat.Mat[2][2];
            mat.Mat[2][3] = 1.0;
            mat.Mat[3][3] = 0.0;
            return mat;
        }

        public Mat4x4 Matrix_MakeIdentity()
        {
            return new Mat4x4();
        }

        public static Mat4x4 operator *(Mat4x4 lhs, Mat4x4 rhs)
        {
            Mat4x4 ans = new Mat4x4();
            
            for(int r=0; r<4; r++)
            {
                for(int c =0; c<4; c++)
                {
                    ans.Mat[r][c] = lhs.Mat[r][0] * rhs.Mat[0][c] + lhs.Mat[r][1] * rhs.Mat[1][c] + lhs.Mat[r][2] * rhs.Mat[2][c] + lhs.Mat[r][3] * rhs.Mat[3][c];
                }
            }

            return ans;
        }

        public static Vec4 operator *(Vec4 lhs, Mat4x4 rhs)
        {
            Vec4 ans = new Vec4();
            return ans;
        }

        public static Mat4x4 operator *(Mat4x4 lhs, double rhs)
        {
            Mat4x4 ans = new Mat4x4();
            for(int i =0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    ans.Mat[i][j] = lhs.Mat[i][j] * rhs;
                }
            }

            return ans;
        }

        public static Mat4x4 operator *(double lhs, Mat4x4 rhs)
        {
            return rhs * lhs;
        }
    }
}
