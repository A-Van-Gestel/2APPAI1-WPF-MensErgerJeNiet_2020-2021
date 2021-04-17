using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MensErgerJeNiet.Model
{
    class Board : ObservableCollection<PionField>
    {

        public Board(string color1, string color2, string color3, string color4, List<Position>positions)
        {
            CreateBoard(color1, color2, color3, color4);
            PutPlayersOnStart(positions);
        }

        private void CreateBoard(string color1, string color2, string color3, string color4)
        {
            // --- Out Fields ---
            // Red Out
            this.Add(new PionField(id: -1, column: 0, row: 0, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: -2, column: 1, row: 0, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: -3, column: 0, row: 1, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: -4, column: 1, row: 1, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));

            // Blue Out
            this.Add(new PionField(id: -11, column: 9, row: 0, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: -12, column: 10, row: 0, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: -13, column: 9, row: 1, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: -14, column: 10, row: 1, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));

            // Green Out
            this.Add(new PionField(id: -21, column: 9, row: 9, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: -22, column: 10, row: 9, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: -23, column: 9, row: 10, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: -24, column: 10, row: 10, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));

            // Yellow Out
            this.Add(new PionField(id: -31, column: 0, row: 9, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: -32, column: 1, row: 9, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: -33, column: 0, row: 10, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: -34, column: 1, row: 10, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));

            // --- Game Fields ---
            // Red Start
            this.Add(new PionField(id: 1, column: 0, row: 4, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: 2, column: 1, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 3, column: 2, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 4, column: 3, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 5, column: 4, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 6, column: 4, row: 3, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 7, column: 4, row: 2, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 8, column: 4, row: 1, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 9, column: 4, row: 0, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 10, column: 5, row: 0, fillColor: new SolidColorBrush(Colors.White)));

            // Blue Start
            this.Add(new PionField(id: 11, column: 6, row: 0, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: 12, column: 6, row: 1, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 13, column: 6, row: 2, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 14, column: 6, row: 3, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 15, column: 6, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 16, column: 7, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 17, column: 8, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 18, column: 9, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 19, column: 10, row: 4, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 20, column: 10, row: 5, fillColor: new SolidColorBrush(Colors.White)));

            // Green Start
            this.Add(new PionField(id: 21, column: 10, row: 6, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: 22, column: 9, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 23, column: 8, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 24, column: 7, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 25, column: 6, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 26, column: 6, row: 7, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 27, column: 6, row: 8, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 28, column: 6, row: 9, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 29, column: 6, row: 10, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 30, column: 5, row: 10, fillColor: new SolidColorBrush(Colors.White)));

            // Yellow Start
            this.Add(new PionField(id: 31, column: 4, row: 10, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: 32, column: 4, row: 9, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 33, column: 4, row: 8, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 34, column: 4, row: 7, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 35, column: 4, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 36, column: 3, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 37, column: 2, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 38, column: 1, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 39, column: 0, row: 6, fillColor: new SolidColorBrush(Colors.White)));
            this.Add(new PionField(id: 40, column: 0, row: 5, fillColor: new SolidColorBrush(Colors.White)));

            // --- Home Fields ---
            // Red Home
            this.Add(new PionField(id: 41, column: 1, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: 42, column: 2, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: 43, column: 3, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));
            this.Add(new PionField(id: 44, column: 4, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color1)));

            // Blue Home
            this.Add(new PionField(id: 51, column: 5, row: 1, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: 52, column: 5, row: 2, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));
            this.Add(new PionField(id: 53, column: 5, row: 3, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2))); ;
            this.Add(new PionField(id: 54, column: 5, row: 4, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color2)));

            // Green Home
            this.Add(new PionField(id: 61, column: 9, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: 62, column: 8, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: 63, column: 7, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));
            this.Add(new PionField(id: 64, column: 6, row: 5, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color3)));

            // Yellow Home
            this.Add(new PionField(id: 71, column: 5, row: 9, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: 72, column: 5, row: 8, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: 73, column: 5, row: 7, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));
            this.Add(new PionField(id: 74, column: 5, row: 6, fillColor: (SolidColorBrush)new BrushConverter().ConvertFrom(color4)));

        }

        public void PutPlayersOnStart(List<Position> positions)
        {
            foreach (Position position in positions)
            {
                if (position.IsActive)
                {
                    var startPionField = this.FirstOrDefault(s => s.ID == position.Coordinate);
                    startPionField.PionOnPionField = position;
                }
                else
                {
                    var startPionField = this.FirstOrDefault(s => s.ID == -(position.Pion + position.PlayerHistory.PionOffset));
                    startPionField.PionOnPionField = position;
                }

            }
        }

        public void MovePion(Position position, int steps)
        {
            PositionDataService contactDS = new PositionDataService();

            // get current PionField
            var PionField = this.FirstOrDefault(s => s.PionOnPionField == position);
            if (PionField != null)
            {
                int currentPionField = PionField.ID;
                // remove old pion from this PionField
                PionField.PionOnPionField = null;
                // get next PionField
                var newPionField = this.FirstOrDefault(s => s.ID == (currentPionField + steps));
                if (newPionField != null)
                {
                    // Move current pion to Out
                    var oldPion = newPionField.PionOnPionField;
                    oldPion.IsActive = false;
                    oldPion.Coordinate = 1;

                    // Move selected pion to PionField
                    newPionField.PionOnPionField = position;

                    // Save both to database
                    contactDS.UpdatePosition(oldPion);
                    contactDS.UpdatePosition(position);
                }
            }
        }
    }
}
