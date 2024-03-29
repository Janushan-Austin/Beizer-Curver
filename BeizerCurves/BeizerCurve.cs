﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeizerCurves
{
    public partial class BeizerCurve : Form
    {
        int CurrentDimension;

        int NumberPoints;
        ExpressionParser BeizerFunction;
        PointClass[] Points;
        List<PointClass> WorldPoints;

        PictureBox PicCanvas;
        Bitmap bm;

        PointClass[] Ranges;
        PointClass CameraPos;

        PointClass LightPos;
        Vec4 LightColor;
        Vec4 DiffuseLight;
        Vec4 AmbientLight;
        double AmbientStrength;

        Vec4 ObjectColor;

        PointClass SphereCenter;
        double SphereRadius;

        PointClass AxisOrigin = null;
        double XAxisLength, YAxisLength, ZAxisLength;

        double TStep;

        PointClass[] InputPoints;

        #region Constructor and Setup functions
        public BeizerCurve()
        {
            InitializeComponent();
            SetupPicture();

            CurrentDimension = 3;

            BeizerFunction = new ExpressionParser();

            Points = new PointClass[5];
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = new PointClass();
            }

            CameraPos = new PointClass(100, 100, -500);
            XCameraTextBox.Text = CameraPos.x.ToString();
            YCameraTextBox.Text = CameraPos.y.ToString();
            ZCameraTextBox.Text = CameraPos.z.ToString();

            Ranges = new PointClass[2];
            for (int i = 0; i < Ranges.Length; i++)
            {
                Ranges[i] = new PointClass();
            }

            //TStep = 0.00001;
            TStep = 0.00002;
            WorldPoints = new List<PointClass>();

            

            while(PointSelecter.Items.Count > 3)
            {
                PointSelecter.Items.RemoveAt(PointSelecter.Items.Count - 1);
            }

            InputPoints = new PointClass[PointSelecter.Items.Count];
            for(int i=0; i< InputPoints.Length; i++)
            {
                InputPoints[i] = new PointClass(i + i*2,i + i*3.7,i + i*2.5);
                //InputPoints[i] = "(" + i.ToString() + "," + i.ToString() +","  + i.ToString() + ")";
                PointSelecter.Items[i] = "Point " + (i + 1).ToString() + ": " + InputPoints[i].ToString();
            }
            PointSelecter.SelectedIndex = 0;

            LightPos = new PointClass(-30, -50, -100, Color.White);
            XLightPosTextBox.Text = LightPos.x.ToString();
            YLightPosTextBox.Text = LightPos.y.ToString();
            ZLightPosTextBox.Text = LightPos.z.ToString();

            LightColor = new Vec4(0.5, 0.75, 0.5);
            LightColorR.Text = ((int)(LightColor.x * 255)).ToString();
            LightColorG.Text = ((int)(LightColor.y * 255)).ToString();
            LightColorB.Text = ((int)(LightColor.z * 255)).ToString();

            AmbientStrength = 0.15;
            AmbientLight = AmbientStrength * LightColor;

            ObjectColor = new Vec4(Color.White);
            ObjectColorRText.Text = ((int)ObjectColor.x * 255).ToString();
            ObjectColorGText.Text = ((int)ObjectColor.y * 255).ToString();
            ObjectColorBText.Text = ((int)ObjectColor.z * 255).ToString();

            SphereCenter = new PointClass();
            SphereRadius = 0.0;


            CreateNewGraph();
        }


        private void CreateNewGraph()
        {
            //"(-1,0, 0), (3, 30,100), (7,13,0), (10, 18, 5)"
            string expr = CreatePoints();
            if (ProccessPoints(expr, ref Points, out NumberPoints))
            {
                //AxisOrigin = new PointClass(Points[0]);

                Ranges = CalculateRange(Points, false);
                AxisOrigin = new PointClass(Ranges[0]);
                XAxisLength = Ranges[1].x - Ranges[0].x;
                YAxisLength = Ranges[1].y - Ranges[0].y;
                ZAxisLength = Ranges[1].z - Ranges[0].z;
                CreateParametricEquation(NumberPoints);
                Draw();
            }
            else
            {
                MessageBox.Show("Invalid set of Points, Please re-enter coordinates in following format: \n" +
                                "\"(x1, y1, z1), (x2,y2,z3), ...\"");
                DrawBackGround();
            }
        }

        private void SetupPicture()
        {
            PicCanvas = new PictureBox
            {
                Size = new Size(ClientSize.Width - 200, ClientSize.Height - 100),
                Name = "picCanvas"
            };
            this.PicCanvas.Location = new System.Drawing.Point(190, 24);
            this.Controls.Add(this.PicCanvas);
            bm = new Bitmap(PicCanvas.ClientSize.Width, PicCanvas.ClientSize.Height);
        }

        private void CreateParametricEquation(int numberPoints)
        {
            int mainPow = numberPoints - 1;
            int secondaryPow = 1;
            int coefficient = 1;
            string equation = "";

            equation += "(1-t)^" + mainPow.ToString() + "*v0";
            coefficient *= mainPow;

            for (; secondaryPow < numberPoints; secondaryPow++)
            {                
                mainPow--;
                coefficient /= secondaryPow;
                equation += "+" + coefficient.ToString() +"*(1-t)^" + mainPow.ToString() + "*t^" + secondaryPow.ToString() + "*v" + secondaryPow.ToString();
                coefficient *= mainPow;               
            }

            BeizerFunction.EvaluateExpression(equation);
        }

        #endregion

        #region Proccess Points

        private string CreatePoints()
        {
            string allPoints = "";

            for (int i = 0; i < InputPoints.Length - 1; i++)
            {
                allPoints += InputPoints[i] + ",";
            }
            allPoints += InputPoints[InputPoints.Length - 1];

            return allPoints;
        }

        private bool ProccessPoints(string pointsList, ref PointClass[] points, out int numberPoints)
        {
            numberPoints = 0;
            if (!DeleteSpaces(ref pointsList))
            {
                //MessageBox.Show("Invalid set of Points");
                return false;
            }
            if (!GetPoints(pointsList, ref points, out numberPoints))
            {
                //MessageBox.Show("Invalid set of Points");
                return false;
            }

            return true;
        }

        private bool ProccessPoint(String point)
        {
            if(!DeleteSpaces(ref point))
            {
                return false;
            }

            PointClass[] points = new PointClass[1];
            points[0] = new PointClass();
            if (!GetPoints(point, ref points, out int x))
            {
                return false;
            }

            return true;
        }

        private bool DeleteSpaces(ref string pointsList)
        {
            string newPoints = "";

            for (int i = 0; i < pointsList.Length; i++)
            {
                if (pointsList[i] == '(' || pointsList[i] == ')' || pointsList[i] == ',' || pointsList[i] == '-' || pointsList[i] == '.' || pointsList[i] == ' ' || (pointsList[i] >= '0' && pointsList[i] <= '9'))
                {
                    if (pointsList[i] != ' ')
                    {
                        newPoints += pointsList[i];
                    }
                }
                else
                {
                    return false;
                }
            }
            pointsList = newPoints;
            return true;
        }

        private bool GetPoints(string Expr, ref PointClass[] points, out int numberPoints)
        {
            numberPoints = 0;
            if(points == null)
            {
                points = new PointClass[5];
                for(int j=0; j< points.Length; j++)
                {
                    points[j] = new PointClass();
                }
            }

            int pointCount = 0;
            int commaCount = 0;
            string currentNumber = "";

            int i = 0;
            while (i < Expr.Length)
            {
                if (Expr[i] != '(')
                {
                    return false;
                }
                i++;

                if (pointCount >= points.Length)
                {
                    ResizePoints(ref points);
                }

                while (i < Expr.Length && Expr[i] != ')')
                {
                    if (Expr[i] == ',')
                    {
                        if (StringIsFloat(currentNumber))
                        {
                            points[pointCount].SetComponent(commaCount, StringToFloat(currentNumber));
                            currentNumber = "";
                        }
                        else
                        {
                            return false;
                        }
                        commaCount++;
                    }
                    else if ((Expr[i] >= '0' && Expr[i] <= '9'))
                    {
                        currentNumber += Expr[i];
                    }
                    else
                    {
                        currentNumber += Expr[i];
                    }
                    i++;

                }
                if (commaCount == CurrentDimension - 1 && StringIsFloat(currentNumber) && i < Expr.Length)
                {
                    points[pointCount].SetComponent(commaCount, StringToFloat(currentNumber));
                }
                else
                {
                    return false;
                }

                pointCount++;
                currentNumber = "";
                commaCount = 0;
                i += 2;

            }

            numberPoints = pointCount;
            return true;
        }

        private void ResizePoints(ref PointClass[] points)
        {
            PointClass[] temp = points;
            points = new PointClass[temp.Length * 2];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointClass();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                points[i].x = temp[i].x;
                points[i].y = temp[i].y;
                points[i].z = temp[i].z;
            }
        }

        private bool StringIsFloat(string number)
        {
            bool decimalFound = false;

            if (number == "")
            {
                return false;
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0 && number[0] == '-')
                {
                    continue;
                }
                if (number[i] < '0' || number[i] > '9')
                {
                    if (number[i] == '.' && !decimalFound)
                    {
                        decimalFound = true;
                        continue;
                    }
                    return false;
                }
            }

            return true;
        }

        private float StringToFloat(String number)
        {
            float value = 0;
            bool negative = number[0] == '-';

            int i = 0;
            if (negative)
            {
                i = 1;
            }
            for (; i < number.Length; i++)
            {
                if (number[i] == '.')
                {
                    break;
                }
                value *= 10;
                value += number[i] - '0';

            }

            float decimalPower = 10;
            for (i = i + 1; i < number.Length; i++)
            {
                value += (number[i] - '0') / decimalPower;
                decimalPower *= 10;
            }

            if (negative)
            {
                value *= -1;
            }
            return value;

        }


        #endregion

        private void Draw()
        {
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.Clear(Color.Black);

                PointClass WorldPoint = new PointClass();

                PointClass[] WorldScreenPoints;

                PointClass pixel = new PointClass(dimension: 2);
                int index;

                Pen pen = new Pen(Color.Blue);
                pen.Width = 1;

                Font font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                SolidBrush brush = new SolidBrush(Color.Red);

                int ax;
                int ay;
                string AxisLetter = "";

                double[] vars = new double[NumberPoints + 1];

                for (double t = 0.0; t <= 1.0; t += TStep)
                {
                    vars[0] = t;
                    for (int i = 0; i < CurrentDimension; i++)
                    {
                        for (int j = 0; j < NumberPoints; j++)
                        {
                            vars[j + 1] = Points[j].GetComponent(i);
                        }
                        WorldPoint.SetComponent(i, BeizerFunction.CalculateExpression(vars));
                    }
                    WorldPoints.AddBack(WorldPoint);
                    WorldPoint = new PointClass();
                }

                List<PointClass> axesPoints = CalculateAxesPoints(AxisOrigin, XAxisLength, YAxisLength, ZAxisLength);

                WorldScreenPoints = new PointClass[WorldPoints.GetLength() + NumberPoints + axesPoints.GetLength()];
                PointClass[] spherePoints = new PointClass[WorldPoints.GetLength()];
                //WorldScreenPoints = new PointClass[WorldPoints.GetLength()];
                int PointCount = WorldPoints.GetLength();
                for (int i = 0; i < PointCount; i++)
                { 
                    WorldScreenPoints[i] = WorldPoints.RemoveFront();
                    WorldScreenPoints[i].Dimension = 3;
                    WorldScreenPoints[i].PointColor = Color.FromArgb((int)(ObjectColor.x*255), (int)(ObjectColor.y*255), (int)(ObjectColor.z*255));
                    spherePoints[i] = WorldScreenPoints[i];
                }

                CreateSphereAroundPoints(spherePoints);


                for (int i = 0; i < NumberPoints; i++)
                {
                    WorldScreenPoints[PointCount + i] = new PointClass(Points[i]);
                    WorldScreenPoints[PointCount + i].Dimension = 2;
                    WorldScreenPoints[PointCount + i].PointColor = Color.White;
                }

                int axesPointCount = axesPoints.GetLength();
                for (int i = 0; i < axesPointCount; i++)
                {
                    WorldScreenPoints[PointCount + NumberPoints + i] = new PointClass(axesPoints.RemoveFront());
                }


                //Let A be CameraPos.x, B be CameraPos.y, D be CameraPos.z
                //Xs = A + (WorldPoint[i].x - A)/(1-WorldPoint[i].z/CameraPos.z)
                for (int i = 0; i < WorldScreenPoints.Length; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        double den = 1 - WorldScreenPoints[i].z / CameraPos.z;
                        double num = WorldScreenPoints[i].GetComponent(j) - CameraPos.GetComponent(j);
                        WorldScreenPoints[i].SetComponent(j, CameraPos.GetComponent(j) + num / den);
                    }
                    //WorldScreenPoints[i].PointSize = (6 * CalculateDepth(WorldScreenPoints[i].z, Ranges));
                    WorldScreenPoints[i].PointSize = (6 / CalculateDistance(WorldScreenPoints[i], CameraPos));
                }

                for(int i=0; i< PointCount; i++)
                {
                    CalculateLighting(WorldScreenPoints[i]);
                }

                Ranges = CalculateRange(WorldScreenPoints);

                double[] dv = new double[WorldScreenPoints[0].Dimension];
                dv[0] = (Ranges[1].x - Ranges[0].x) / PicCanvas.ClientSize.Width;
                dv[1] = (Ranges[1].y - Ranges[0].y) / PicCanvas.ClientSize.Height;
                if (dv[0] == 0.0)
                {
                    dv[0] = 0.001;
                }
                if (dv[1] == 0.0)
                {
                    dv[1] = 0.001;
                }

                WorldPoint.Dimension = 2;

                index = WorldScreenPoints.Length - axesPointCount;
                WorldPoint = WorldScreenPoints[index];
                ax = (int)((WorldPoint.x - Ranges[0].x) / dv[0]);
                ay = (int)((WorldPoint.y - Ranges[0].y) / dv[1]);
                index++;

                for (; index < WorldScreenPoints.Length-axesPointCount+4; index++)
                {
                    WorldPoint = WorldScreenPoints[index];
                    pixel.x = (WorldPoint.x - Ranges[0].x) / dv[0];
                    pixel.y = (WorldPoint.y - Ranges[0].y) / dv[1];
                    pen.Color = WorldPoint.PointColor;

                    if(index == WorldScreenPoints.Length -axesPointCount + 3)
                    {
                        AxisLetter = "z";
                        g.DrawString(AxisLetter, font, brush, (int)pixel.x, PicCanvas.ClientSize.Height - (int)pixel.y);
                    }
                    else if(index == WorldScreenPoints.Length -axesPointCount + 2)
                    {
                        AxisLetter = "y";
                        g.DrawString(AxisLetter, font, brush, (int)pixel.x, PicCanvas.ClientSize.Height - (int)pixel.y);
                    }
                    else
                    {
                        AxisLetter = "x";
                        g.DrawString(AxisLetter, font, brush, (int)pixel.x, PicCanvas.ClientSize.Height - (int)pixel.y);
                    }

                    if ((int)pixel.x < PicCanvas.ClientSize.Width && (int)pixel.x >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) < PicCanvas.ClientSize.Height)
                    {
                        g.DrawLine(pen, ax, PicCanvas.ClientSize.Height - ay, (int)pixel.x, (PicCanvas.ClientSize.Height - (int)pixel.y));
                        
                    }
                }

                WorldPoint = WorldScreenPoints[0];
                ax = (int)((WorldPoint.x - Ranges[0].x) / dv[0]);
                ay = (int)((WorldPoint.y - Ranges[0].y) / dv[1]);

                for (index = 1; index < (WorldScreenPoints.Length-axesPointCount) - NumberPoints; index++)
                {
                    WorldPoint = WorldScreenPoints[index];
                    pixel.x = (WorldPoint.x - Ranges[0].x) / dv[0];
                    pixel.y = (WorldPoint.y - Ranges[0].y) / dv[1];
                    //pixel.PointColor = WorldPoint.PointColor;
                    pen.Color = WorldPoint.PointColor;
                    pen.Width = (float)WorldPoint.PointSize;

                    if ((int)pixel.x < PicCanvas.ClientSize.Width && (int)pixel.x >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) < PicCanvas.ClientSize.Height)
                    {
                        //bm.SetPixel((int)pixel.x, (int)(PicCanvas.ClientSize.Height - pixel.y), pixel.PointColor);
                        g.DrawLine(pen, ax, PicCanvas.ClientSize.Height - ay, (int)pixel.x, (PicCanvas.ClientSize.Height - (int)pixel.y));
                    }

                    ax = (int)pixel.x;
                    ay = (int)pixel.y;
                }

                WorldPoint = WorldScreenPoints[index];
                ax = (int)((WorldPoint.x - Ranges[0].x) / dv[0]);
                ay = (int)((WorldPoint.y - Ranges[0].y) / dv[1]);
                pen.Color = WorldPoint.PointColor;
                index++;

                if (ConnectPointsCheckBox.Checked == true)
                {
                    pen.Width = 1;
                    //Draw Lines between the user defined points
                    for (; index < WorldScreenPoints.Length - axesPointCount; index++)
                    {
                        WorldPoint = WorldScreenPoints[index];
                        pixel.x = (WorldPoint.x - Ranges[0].x) / dv[0];
                        pixel.y = (WorldPoint.y - Ranges[0].y) / dv[1];
                        //pixel.PointColor = WorldPoint.PointColor;
                        pen.Color = WorldPoint.PointColor;

                        if ((int)pixel.x < PicCanvas.ClientSize.Width && (int)pixel.x >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) < PicCanvas.ClientSize.Height)
                        {
                            //bm.SetPixel((int)pixel.x, (int)(PicCanvas.ClientSize.Height - pixel.y), pixel.PointColor);
                            g.DrawLine(pen, ax, PicCanvas.ClientSize.Height - ay, (int)pixel.x, (PicCanvas.ClientSize.Height - (int)pixel.y));
                        }

                        ax = (int)pixel.x;
                        ay = (int)pixel.y;
                    }
                }

                PicCanvas.Image = bm;
            }
        }

        private void DrawBackGround(Color color = default(Color))
        {
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.Clear(Color.Black);
                PicCanvas.Image = bm;
            }
        }


        private void CreateSphereAroundPoints(PointClass[] points)
        {
            PointClass[] ranges = CalculateRange(points);
            SphereCenter = CalculateGravity(points);

            SphereRadius = Math.Abs(ranges[0].x - SphereCenter.x);

            for (int i=0; i<ranges.Length; i++)
            {
                if(Math.Abs(ranges[i].x - SphereCenter.x) > SphereRadius)
                {
                    SphereRadius = Math.Abs(ranges[i].x - SphereCenter.x);
                }
                if (Math.Abs(ranges[i].y - SphereCenter.y) > SphereRadius)
                {
                    SphereRadius = Math.Abs(ranges[i].y - SphereCenter.y);
                }
                if (Math.Abs(ranges[i].z - SphereCenter.z) > SphereRadius)
                {
                    SphereRadius = Math.Abs(ranges[i].z - SphereCenter.z);
                }
            }
        }

        private PointClass CalculateGravity(PointClass[] points)
        {
            PointClass center = new PointClass();

            for(int i=0; i< points.Length; i++)
            {
                center += points[i];
            }

            center.x /= points.Length;
            center.y /= points.Length;
            center.z /= points.Length;

            return center;
        }

        private void CalculateLighting(PointClass screenPoint)
        {
            PointClass spherePoint = new PointClass(), sphereNormal;
            Vec4 normal, lightNormal;
            double A, B, C, t, dot;

            A = Math.Pow(CameraPos.x - screenPoint.x, 2) + Math.Pow(CameraPos.y - screenPoint.y, 2) + Math.Pow(CameraPos.z, 2);
            B = (CameraPos.x - screenPoint.x) * (CameraPos.x - SphereCenter.x) + (CameraPos.y - screenPoint.y) * (CameraPos.y - SphereCenter.y) + (CameraPos.z) * (CameraPos.z - SphereCenter.z);
            C = Math.Pow(CameraPos.x - SphereCenter.x, 2) + Math.Pow(CameraPos.y - SphereCenter.y, 2) + Math.Pow(CameraPos.z- SphereCenter.z, 2) - Math.Pow(SphereRadius,2);

            t = (B - Math.Sqrt(Math.Pow(B, 2) - A * C)) / A;

            spherePoint.x = CameraPos.x * (1 - t) + screenPoint.x * t;
            spherePoint.y = CameraPos.y * (1 - t) + screenPoint.y * t;
            spherePoint.z = CameraPos.z * (1 - t);

            //Calculate the normal, tagent to the sphere surface
            sphereNormal = spherePoint - SphereCenter;
            normal = new Vec4(sphereNormal.x, sphereNormal.y, sphereNormal.z);

            //Calculate vector from Sphere surface to light source
            sphereNormal = LightPos - spherePoint;
            lightNormal = new Vec4(sphereNormal.x, sphereNormal.y, sphereNormal.z);

            normal = Vec4.Normal(normal);
            lightNormal = Vec4.Normal(lightNormal);

            dot = normal.Dot(lightNormal);
            if(dot < 0)
            {
                dot = 0;
            }

            DiffuseLight = dot * LightColor;
            Vec4 pointColor = new Vec4(screenPoint.PointColor);
           // pointColor *= 1/(double)255;

            pointColor = (AmbientLight + DiffuseLight) * pointColor;

            if(pointColor.x > 1)
            {
                pointColor.x = 1;
            }
            if (pointColor.y > 1)
            {
                pointColor.y = 1;
            }
            if (pointColor.z > 1)
            {
                pointColor.z = 1;
            }

            screenPoint.PointColor = Color.FromArgb((int)(255 * pointColor.x), (int)(255 * pointColor.y), (int)(255 * pointColor.z));

            //screenPoint.PointColor = Color.FromArgb((int)(DiffuseLight * dot) + AmbientLight, (int)(DiffuseLight * dot) + AmbientLight, (int)(DiffuseLight * dot) + AmbientLight);

        }

        private List<PointClass> CalculateAxesPoints(PointClass origin, double xLength, double yLength, double zLength)
        {
            List<PointClass> list = new List<PointClass>();

            xLength = Math.Abs(xLength);
            yLength = Math.Abs(yLength);
            zLength = Math.Abs(zLength);

            double rangeX = xLength - origin.x;
            double rangeY = yLength - origin.y;
            double rangeZ = zLength - origin.z;

            list.AddBack(new PointClass(origin));
            list.AddBack(new PointClass(new PointClass(origin.x +xLength, origin.y, origin.z, Color.Pink)));
            list.AddBack(new PointClass(new PointClass(origin.x, origin.y + yLength, origin.z, Color.Pink)));
            list.AddBack(new PointClass(new PointClass(origin.x, origin.y, origin.z +zLength, Color.Pink)));

            return list;
        }

        private double CalculateDepth(double z, PointClass[] ranges)
        {
            return  1 - (z / (ranges[1].z - ranges[0].z));
        }

        private double CalculateDistance(PointClass pt1, PointClass pt2)
        {
            return Math.Sqrt(Math.Pow(pt2.x - pt1.x, 2) + Math.Pow(pt2.y - pt1.y, 2) + Math.Pow(pt2.z - pt1.z,2));
        }

        private PointClass[] CalculateRange(PointClass[] points, bool WidenRange = true)
        {
            //PointClass Maxs = new PointClass(dimension: points[0].Dimension), Mins = new PointClass(dimension: points[0].Dimension);
            PointClass[] ranges = new PointClass[2];
            PointClass[] Maxs = new PointClass[2];
            Maxs[0] = new PointClass(points[0]);
            Maxs[1] = new PointClass(points[0]);

            PointClass currentPoint;

            for (int i = 0; i < points.Length; i++)
            {
                currentPoint = points[i];
                for (int j = 0; j < Maxs[0].Dimension; j++)
                {                    
                    if (Maxs[1].GetComponent(j) < currentPoint.GetComponent(j))
                    {
                        Maxs[1].SetComponent(j, currentPoint.GetComponent(j));
                    }
                    else if (Maxs[0].GetComponent(j) > currentPoint.GetComponent(j))
                    {
                        Maxs[0].SetComponent(j, currentPoint.GetComponent(j));
                    }
                }
            }


            ranges[0] = Maxs[0];
            ranges[1] = Maxs[1];

            for (int i = 0; i < ranges[0].Dimension; i++)
            {
                if (WidenRange == true)
                {
                    ranges[0].SetComponent(i, ranges[0].GetComponent(i) - (ranges[1].GetComponent(i) - ranges[0].GetComponent(i)) * 0.2);
                    ranges[1].SetComponent(i, ranges[1].GetComponent(i) + (ranges[1].GetComponent(i) - ranges[0].GetComponent(i)) * 0.2);
                }

                if(ranges[1].GetComponent(i) - ranges[0].GetComponent(i) <= 0)
                {
                    ranges[1].SetComponent(i, ranges[1].GetComponent(i) + 1);
                }
            }

            return ranges;
        }

        private void PointSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PointSelecter.SelectedIndex >=0 && InputPoints[PointSelecter.SelectedIndex] != null)
            {
                XPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].x,2).ToString();
                YPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].y,2).ToString();
                ZPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].z,2).ToString();
            }
            else if(PointSelecter.SelectedIndex < 0)
            {
                XPointTextBox.Text = "";
                YPointTextBox.Text = "";
                ZPointTextBox.Text = "";
            }
            else
            {
                //XPointTextBox.Text = "0";
                //YPointTextBox.Text = "0"; 
                //ZPointTextBox.Text = "0";
                //PointSelecter.Items[PointSelecter.SelectedIndex] = "Point " + (PointSelecter.SelectedIndex + 1).ToString() +
                MessageBox.Show("Program broke!!!!!");
            }
        }

       
    }


}
