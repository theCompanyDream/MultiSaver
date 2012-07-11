﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using subform = System.Windows.Forms;

namespace WPF_Practice.MonitorControls
{
    /// <summary>
    /// Interaction logic for SlideShowConfig.xaml
    /// </summary>
    public partial class SlideShowConfig : UserControl
    {
        public string fadeTypes
        {
            get { return (FadeTypes.SelectedItem as ComboBoxItem).Content.ToString(); }
            set { (FadeTypes.SelectedItem as ComboBoxItem).Content = value; }
        }

        public int FadeTime
        {
            get { return comboFadeTime.SelectedIndex+1; }
            set { comboFadeTime.SelectedIndex = value; }
        }
        public int DisplayTime
        {
            get{return comboDisplayTime.SelectedIndex + 1;}
            set { comboDisplayTime.SelectedIndex = value; }
        }

        public string location
        {
            get { return pictureLocation.Text; }
            set { pictureLocation.Text = value; }
        }

        public int PanTime
        {
            get {return comboDisplayTime.SelectedIndex + 1;}
            set { comboDisplayTime.SelectedIndex = value; }
        }
        public int Rotation
        {
            get{return comboRotation.SelectedIndex + 1;}
            set { comboRotation.SelectedIndex = value; }
        }
        public bool Clockwise
        {
            get { return (bool)isClockwise.IsChecked; }
            set { isClockwise.IsChecked = value; }
        }
        public char DirectionInChar
        {
            get
            {
                string tmp = (directionInBox.SelectedItem as ComboBoxItem).Content.ToString();
                return tmp[0];
            }
            set
            {
                string tmp = value.ToString();
                setDirectionComparisions(tmp, directionInBox);
            }
        }
        public char DirectionOutChar
        {
            get
            {
                string tmp = (directionoutBox.SelectedItem as ComboBoxItem).Content.ToString();
                return tmp[0];
            }
            set
            {
                string tmp = value.ToString();
                setDirectionComparisions(tmp, directionoutBox);
            }
        }

        public string Order
        {
            get {return (orderComboBox.SelectedItem as ComboBoxItem).Content.ToString();}
            set { orderComboBox.SelectedIndex = setOrderComparisions(value); }
        }

        public SlideShowConfig()
        {
            InitializeComponent();
        }

        //function is only used to set direction txt boxes
        private void setDirectionComparisions(string tmp, ComboBox tmpCombo)
        {
            if (String.Equals(tmp, "North", StringComparison.InvariantCultureIgnoreCase))
                tmpCombo.SelectedIndex = 0;
            else if (String.Equals(tmp, "South", StringComparison.InvariantCultureIgnoreCase))
                tmpCombo.SelectedIndex = 1;
            else if (String.Equals(tmp, "West", StringComparison.InvariantCultureIgnoreCase))
                tmpCombo.SelectedIndex = 2;
            else if (String.Equals(tmp, "East", StringComparison.InvariantCultureIgnoreCase))
                tmpCombo.SelectedIndex = 3;
        }

        private int setOrderComparisions(string tmp)
        {
            if(String.Equals("Alphabetical", tmp, StringComparison.InvariantCultureIgnoreCase))
                return 0;
            else if(String.Equals("RevAlphabetical", tmp, StringComparison.InvariantCultureIgnoreCase))
                return 1;
            else if(String.Equals("Random", tmp, StringComparison.InvariantCultureIgnoreCase))
                return 2;
            return 0;
        }

        public void fillForm(GroupSetting gSetting, int numberscreen)
        {
            FadeTime = gSetting.monitors[numberscreen].fadeTime - 1;
            DisplayTime = gSetting.monitors[numberscreen].displayTime - 1;
            PanTime = gSetting.monitors[numberscreen].panTime - 1;
            Rotation = gSetting.monitors[numberscreen].numRotations - 1;
            directionInBox.SelectedIndex = gSetting.monitors[numberscreen].dirIn;
            directionoutBox.SelectedIndex = gSetting.monitors[numberscreen].dirOut;
            Clockwise = gSetting.monitors[numberscreen].clockwise;
            Order = gSetting.order;
            location = gSetting.albumLocation;


            
        }

        public void getFormInfo(GroupSetting gSetting, int numberscreen)
        {
            gSetting.monitors[numberscreen].fadeTime = FadeTime;
            gSetting.monitors[numberscreen].displayTime = DisplayTime;
            gSetting.monitors[numberscreen].panTime = PanTime;
            gSetting.monitors[numberscreen].numRotations = Rotation;
            gSetting.monitors[numberscreen].dirIn = directionInBox.SelectedIndex;
            gSetting.monitors[numberscreen].dirOut = directionoutBox.SelectedIndex;
            gSetting.monitors[numberscreen].clockwise = Clockwise;
            gSetting.order = Order;
            gSetting.albumLocation = location;

            gSetting.mazeSize = 0;
            gSetting.mazePalletName = " ";
            gSetting.monitors[numberscreen].aiMethod = " ";
            gSetting.monitors[numberscreen].aiView = " ";
            gSetting.ssType = "SlideShow";
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void fineFileButtonClick(object sender, RoutedEventArgs e)
        {
            subform.FolderBrowserDialog folderDialog = new subform.FolderBrowserDialog();
            folderDialog.SelectedPath = "C:\\";

            subform.DialogResult result = folderDialog.ShowDialog();
            if (result.ToString() == "OK")
                pictureLocation.Text = folderDialog.SelectedPath;
        }
    }
}
