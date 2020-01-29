using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


# region UI_Control functions
namespace BeizerCurves
{
    public partial class BeizerCurve
    {

        private void AddPointButton_Click(object sender, EventArgs e)
        {
            PointSelecter.Items.Add("Point " + (PointSelecter.Items.Count + 1).ToString() + ": ");
            PointClass[] inputs = InputPoints;
            InputPoints = new PointClass[PointSelecter.Items.Count];
            if (inputs != null)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    InputPoints[i] = new PointClass(inputs[i]);
                }
                InputPoints[InputPoints.Length - 1] = new PointClass(InputPoints[inputs.Length - 1]);
            }
            else
            {
                InputPoints[InputPoints.Length - 1] = new PointClass(0, 0, 0);
            }

            PointSelecter.SelectedIndex = PointSelecter.Items.Count - 1;
            PointSelecter.Items[PointSelecter.SelectedIndex] += InputPoints[PointSelecter.SelectedIndex].ToString();
        }

        private void RemovePointButton_Click(object sender, EventArgs e)
        {
            if (PointSelecter.Items.Count > 0)
            {
                PointSelecter.Items.RemoveAt(PointSelecter.Items.Count - 1);
            }

            if (PointSelecter.Items.Count > 0)
            {
                if (PointSelecter.SelectedIndex == -1)
                {
                    PointSelecter.SelectedIndex = PointSelecter.Items.Count - 1;
                    XPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].x, 2).ToString();
                    YPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].y, 2).ToString();
                    ZPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].z, 2).ToString();
                }

                PointClass[] inputPoints = InputPoints;
                if (PointSelecter.Items.Count > 0)
                {

                    InputPoints = new PointClass[PointSelecter.Items.Count];
                    for (int i = 0; i < InputPoints.Length; i++)
                    {
                        InputPoints[i] = inputPoints[i];
                    }
                }

                CreateNewGraph();
            }
            else
            {
                InputPoints = null;
                XPointTextBox.Text = "";
                YPointTextBox.Text = "";
                ZPointTextBox.Text = "";
            }
        }

        private void UpdatePointButton_Click(object sender, EventArgs e)
        {
            PointClass point = new PointClass();
            if (StringIsFloat(XPointTextBox.Text) == false)
            {
                XPointTextBox.Text = "0";
            }
            point.x = StringToFloat(XPointTextBox.Text);

            if (StringIsFloat(YPointTextBox.Text) == false)
            {
                YPointTextBox.Text = "0";
            }
            point.y = StringToFloat(YPointTextBox.Text);

            if (StringIsFloat(ZPointTextBox.Text) == false)
            {
                ZPointTextBox.Text = "0";
            }
            point.z = StringToFloat(ZPointTextBox.Text);

            if (PointSelecter.SelectedIndex >= 0 && ProccessPoint(point.ToString()))
            {
                InputPoints[PointSelecter.SelectedIndex] = point;
                PointSelecter.Items[PointSelecter.SelectedIndex] = "Point " + (PointSelecter.SelectedIndex + 1).ToString() + ": " + point;
                CreateNewGraph();
            }
            else
            {

                MessageBox.Show("Ivalid Point entered for Point" + (PointSelecter.SelectedIndex + 1).ToString());
            }
        }

        private void ConnectPointsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InputPoints?.Length > 0)
            {
                CreateNewGraph();
            }
        }

        private void AddHereButton_Click(object sender, EventArgs e)
        {
            if (PointSelecter.Items.Count <= 0)
            {
                AddPointButton_Click(null, null);
                return;
            }
            PointClass[] inputs = InputPoints;
            PointSelecter.Items.Add("Point " + (PointSelecter.Items.Count + 1).ToString() + ": ");
            InputPoints = new PointClass[PointSelecter.Items.Count];
            int i = 0;
            for (; i <= PointSelecter.SelectedIndex; i++)
            {
                InputPoints[i] = inputs[i];
            }
            for (; i < PointSelecter.Items.Count; i++)
            {
                InputPoints[i] = inputs[i - 1];
                PointSelecter.Items[i] = "Point " + (i + 1).ToString() + ": " + inputs[i - 1].ToString();
            }

        }



        private void RemoveHereButton_Click(object sender, EventArgs e)
        {
            if (PointSelecter.SelectedIndex >= 0)
            {
                PointClass[] inputs = InputPoints;

                for (int i = PointSelecter.SelectedIndex; i < PointSelecter.Items.Count - 1; i++)
                {
                    inputs[i] = inputs[i + 1];
                    PointSelecter.Items[i] = "Point " + (i + 1).ToString() + inputs[i].ToString();
                }
                PointSelecter.Items.RemoveAt(PointSelecter.Items.Count - 1);
                if (PointSelecter.Items.Count > 0)
                {
                    InputPoints = new PointClass[PointSelecter.Items.Count];
                    for (int i = 0; i < InputPoints.Length; i++)
                    {
                        InputPoints[i] = inputs[i];
                    }
                    if (PointSelecter.SelectedIndex >= 0)
                    {
                        XPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].x, 2).ToString();
                        YPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].y, 2).ToString();
                        ZPointTextBox.Text = Math.Round(InputPoints[PointSelecter.SelectedIndex].z, 2).ToString();
                    }
                    else
                    {
                        PointSelecter.SelectedIndex = PointSelecter.Items.Count - 1;
                    }
                }
                else
                {
                    InputPoints = null;
                    XPointTextBox.Text = "";
                    YPointTextBox.Text = "";
                    ZPointTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select a valid point to remove");
            }
        }

        private void LightColorChangeButton_Click(object sender, EventArgs e)
        {
            if (StringIsFloat(LightColorR.Text) && StringIsFloat(LightColorG.Text) && StringIsFloat(LightColorB.Text))
            {
                //newCameraPos = new PointClass();
                LightColor.x = StringToFloat(LightColorR.Text) / 255;
                LightColor.y = StringToFloat(LightColorG.Text) / 255;
                LightColor.z = StringToFloat(LightColorB.Text) / 255;
                AmbientLight = AmbientStrength * LightColor;
                CreateNewGraph();
            }
            else
            {
                MessageBox.Show("Invalid Light color provided.");
            }
        }

        private void ObjectColorButton_Click(object sender, EventArgs e)
        {
            if (StringIsFloat(ObjectColorRText.Text) && StringIsFloat(ObjectColorGText.Text) && StringIsFloat(ObjectColorBText.Text))
            {
                //newCameraPos = new PointClass();
                ObjectColor.x = StringToFloat(ObjectColorRText.Text) / 255;
                ObjectColor.y = StringToFloat(ObjectColorGText.Text) / 255;
                ObjectColor.z = StringToFloat(ObjectColorBText.Text) / 255;
                CreateNewGraph();
            }
            else
            {
                MessageBox.Show("Invalid Object color provided.");
            }
        }

        private void CameraChangeButton_Click(object sender, EventArgs e)
        {
            if (StringIsFloat(XCameraTextBox.Text) && StringIsFloat(YCameraTextBox.Text) && StringIsFloat(ZCameraTextBox.Text))
            {
                //newCameraPos = new PointClass();
                CameraPos.x = StringToFloat(XCameraTextBox.Text);
                CameraPos.y = StringToFloat(YCameraTextBox.Text);
                CameraPos.z = StringToFloat(ZCameraTextBox.Text);
                CreateNewGraph();
            }
            else
            {
                MessageBox.Show("Invalid Camera position provided.");
            }
        }

        private void LightPositionButton_Click(object sender, EventArgs e)
        {
            if (StringIsFloat(XLightPosTextBox.Text) && StringIsFloat(YLightPosTextBox.Text) && StringIsFloat(ZLightPosTextBox.Text))
            {
                //newCameraPos = new PointClass();
                LightPos.x = StringToFloat(XLightPosTextBox.Text);
                LightPos.y = StringToFloat(YLightPosTextBox.Text);
                LightPos.z = StringToFloat(ZLightPosTextBox.Text);
                CreateNewGraph();
            }
            else
            {
                MessageBox.Show("Invalid Light position provided.");
            }
        }

    }
}

#endregion