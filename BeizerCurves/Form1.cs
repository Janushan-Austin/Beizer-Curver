using System;
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

        PointClass AxisOrigin = null;
        PointClass XAxis, YAxis, ZAxis;
        double XAxisLength, YAxisLength, ZAxisLength;

        double TStep;

        #region Constructor and Setup functions
        public BeizerCurve()
        {
            CurrentDimension = 3;
            
            BeizerFunction = new ExpressionParser();

            Points = new PointClass[5];
            for(int i=0; i< Points.Length; i++)
            {
                Points[i] = new PointClass();
            }

            CameraPos = new PointClass(0, 0, -500.5);

            Ranges = new PointClass[2];
            for(int i=0; i<Ranges.Length; i++)
            {
                Ranges[i] = new PointClass();
            }

            //TStep = 0.00001;
            TStep = 0.0001;
            WorldPoints = new List<PointClass>();

            InitializeComponent();
            SetupPicture();

            XAxis = new PointClass(); YAxis = new PointClass(); ZAxis = new PointClass();
            

            //ProccessPoints("(-2,-1) , (0,-13), (0,-14), (0.25,-14.59), (0.3, -14), (1.51, 0)");
            //ProccessPoints("(-1,0, 2), (1, 15,7) ,(3,8,100), (7,6,15)");


            if (ProccessPoints("(-1,0, 0), (3, 7,500),     (7,3,0)", ref Points, out NumberPoints))
            {
                //AxisOrigin = new PointClass(Points[0]);
                
                Ranges = CalculateRange(Points, false);
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
                Size = new Size(ClientSize.Width - 100, ClientSize.Height - 100),
                Name = "picCanvas"
            };
            this.PicCanvas.Location = new System.Drawing.Point(90, 50);
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
            //MessageBox.Show(BeizerFunction.GetVars());
        }

        #endregion

        #region Proccess Points

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
                if (commaCount == CurrentDimension - 1 && StringIsFloat(currentNumber))
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


                AxisOrigin = new PointClass(WorldPoints.Index(0));

                XAxis.x = AxisOrigin.x + XAxisLength;
                XAxis.PointColor = Color.Pink;

                YAxis.y = AxisOrigin.y + YAxisLength;
                YAxis.PointColor = Color.Pink;

                ZAxis.z = AxisOrigin.z + ZAxisLength;
                ZAxis.PointColor = Color.Pink;

                WorldScreenPoints = new PointClass[WorldPoints.GetLength() + NumberPoints + 4];
                //WorldScreenPoints = new PointClass[WorldPoints.GetLength()];
                int PointCount = WorldPoints.GetLength();
                for (int i = 0; i < PointCount; i++)
                {
                    WorldScreenPoints[i] = WorldPoints.RemoveFront();
                    WorldScreenPoints[i].Dimension = 2;
                    WorldScreenPoints[i].PointColor = Color.Green;
                }


                for (int i = 0; i < NumberPoints; i++)
                {
                    WorldScreenPoints[PointCount + i] = new PointClass(Points[i]);
                    WorldScreenPoints[PointCount + i].Dimension = 2;
                    WorldScreenPoints[PointCount + i].PointColor = Color.White;
                }


                WorldScreenPoints[PointCount + NumberPoints] = new PointClass(AxisOrigin);
                WorldScreenPoints[PointCount + NumberPoints + 1] = new PointClass(XAxis);
                WorldScreenPoints[PointCount + NumberPoints + 2] = new PointClass(YAxis);
                WorldScreenPoints[PointCount + NumberPoints + 3] = new PointClass(ZAxis);



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

                for (index = 0; index < WorldScreenPoints.Length-4; index++)
                {
                    WorldPoint = WorldScreenPoints[index];
                    pixel.x = (WorldPoint.x - Ranges[0].x) / dv[0];
                    pixel.y = (WorldPoint.y - Ranges[0].y) / dv[1];
                    pixel.PointColor = WorldPoint.PointColor;

                    if ((int)pixel.x < PicCanvas.ClientSize.Width && (int)pixel.x >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) < PicCanvas.ClientSize.Height)
                    {
                        bm.SetPixel((int)pixel.x, (int)(PicCanvas.ClientSize.Height - pixel.y), pixel.PointColor);
                    }
                }

                WorldPoint = WorldScreenPoints[index];
                int ax = (int)((WorldPoint.x - Ranges[0].x) / dv[0]);
                int ay = (int)((WorldPoint.y - Ranges[0].y) / dv[1]);
                index++;

                for (; index < WorldScreenPoints.Length; index++)
                {
                    WorldPoint = WorldScreenPoints[index];
                    pixel.x = (WorldPoint.x - Ranges[0].x) / dv[0];
                    pixel.y = (WorldPoint.y - Ranges[0].y) / dv[1];
                    pen.Color = WorldPoint.PointColor;

                    if ((int)pixel.x < PicCanvas.ClientSize.Width && (int)pixel.x >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) >= 0 && (int)(PicCanvas.ClientSize.Height - pixel.y) < PicCanvas.ClientSize.Height)
                    {
                        g.DrawLine(pen, ax, PicCanvas.ClientSize.Height - ay, (int)pixel.x, (int)(PicCanvas.ClientSize.Height-pixel.y));
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

        private Point CalculateProjection(Point p)
        {
            Point ProjectedPoint = new Point();

            return ProjectedPoint;
        }

        private void SetCameraPos()
        {
            PointClass Maxs = new PointClass(), Mins = new PointClass();

            Maxs = WorldPoints.Index(0);
            Mins = WorldPoints.Index(0);

            for (int i = 0; i < WorldPoints.GetLength(); i++)
            {

                for (int j = 0; j < CurrentDimension; j++)
                {
                    if (Maxs.GetComponent(j) > WorldPoints.Index(i).GetComponent(j))
                    {
                        Maxs.SetComponent(j, WorldPoints.Index(i).GetComponent(j));
                    }
                    else if (Mins.GetComponent(j) < WorldPoints.Index(i).GetComponent(j))
                    {
                        Mins.SetComponent(j, WorldPoints.Index(i).GetComponent(j));
                    }
                }
            }
            for (int i = 0; i < CurrentDimension; i++)
            {
                if (Math.Abs(Maxs.GetComponent(i)) > Math.Abs(Mins.GetComponent(i)))
                {
                    if (Maxs.GetComponent(i) > 0)
                    {
                        Ranges[0].SetComponent(i,-Maxs.GetComponent(i));
                        Ranges[1].SetComponent(i, Maxs.GetComponent(i));
                    }
                    else
                    {
                        Ranges[0].SetComponent(i, Maxs.GetComponent(i));
                        Ranges[1].SetComponent(i, -Maxs.GetComponent(i));
                    }
                }
                else
                {
                    if (Mins.GetComponent(i) < 0)
                    {
                        Ranges[0].SetComponent(i, Mins.GetComponent(i));
                        Ranges[1].SetComponent(i, -Mins.GetComponent(i));
                    }
                    else
                    {
                        Ranges[0].SetComponent(i, -Mins.GetComponent(i));
                        Ranges[1].SetComponent(i, Mins.GetComponent(i));
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                CameraPos.SetComponent(i, (Ranges[0].GetComponent(i) + Ranges[1].GetComponent(i)) / 2);
                Ranges[0].SetComponent(i,  Ranges[0].GetComponent(i) + Math.Abs(Ranges[0].GetComponent(i)) * -0.05);
                Ranges[1].SetComponent(i, Ranges[1].GetComponent(i) + Ranges[1].GetComponent(i) * 0.05);
            }

            CameraPos.z = -1;
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
            if (WidenRange == true)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    ranges[0].SetComponent(i, ranges[0].GetComponent(i) - (ranges[1].GetComponent(i) - ranges[0].GetComponent(i)) * 0.2);
                    ranges[1].SetComponent(i, ranges[1].GetComponent(i) + (ranges[1].GetComponent(i) - ranges[0].GetComponent(i)) * 0.2);
                }
            }

            return ranges;
        }

        private void CameraChangeButton_Click(object sender, EventArgs e)
        {
            PointClass[] newCameraPos = null;
            if (ProccessPoints(DeltaCameraInput.Text, ref newCameraPos, out int numberPoints))
            {
                if (numberPoints > 1)
                {
                    MessageBox.Show("Too many points provided for the Camera position, using the first found point\n" +
                                    "Use format: \"(x1, y1, z1)\"");
                }
                else if (numberPoints <= 0)
                {
                    MessageBox.Show("No valid point provided for new Camera position" +
                                    "Use format: \"(x1, y1, z1)\"");
                    return;
                }
                CameraPos = new PointClass(newCameraPos[0]);
                Draw();
            }
            else
            {
                MessageBox.Show("No valid point provided for new Camera position\n" +
                                "Use format: \"(x1, y1, z1)\"");
            }
        }
    }


}
