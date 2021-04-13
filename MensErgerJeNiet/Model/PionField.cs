﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MensErgerJeNiet.Model
{
    class PionField : BaseModel
    {
        private int id;
        private int column;
        private int row;
        private SolidColorBrush fillColor;
        private SolidColorBrush pionColor = new SolidColorBrush(Colors.Turquoise);
        private string pionText = "test";
        private string pionVisibility = "Hidden";  // "Visible" | "Hidden"
        private List<int> playersOnPionField;
        // Debug
        private string debugVisibility = "Visible";  // "Visible" | "Hidden"

        public PionField(int id, int column, int row, SolidColorBrush fillColor)
        {
            ID = id;
            Column = column;
            Row = row;
            FillColor = fillColor;
            playersOnPionField = new List<int>();
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                NotifyPropertyChanged();
            }
        }

        public int Column
        {
            get { return column; }
            set
            {
                column = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush PionColor
        {
            get { return pionColor; }
            set
            {
                pionColor = value;
                NotifyPropertyChanged();
            }
        }

        public string PionText
        {
            get { return pionText; }
            set
            {
                pionText = value;
                NotifyPropertyChanged();
            }
        }

        public string PionVisibility
        {
            get { return pionVisibility; }
            set
            {
                pionVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                NotifyPropertyChanged();
            }
        }


        public List<int> PlayersOnPionField
        {
            get { return playersOnPionField; }
            set
            {
                playersOnPionField = value;
                NotifyPropertyChanged("Content");
            }
        }

        // Debug
        public string DebugVisibility
        {
            get { return debugVisibility; }
            set
            {
                debugVisibility = value;
                NotifyPropertyChanged();
            }
        }

    }
}