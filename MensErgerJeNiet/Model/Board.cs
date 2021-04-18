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

        public Board(string color1, string color2, string color3, string color4, List<Pion>pions)
        {
            CreateBoard(color1, color2, color3, color4);
            PutPlayersOnStart(pions);
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

        public void PutPlayersOnStart(List<Pion> pions)
        {
            foreach (Pion pion in pions)
            {
                if (pion.IsActive)
                {
                    var startPionField = this.FirstOrDefault(s => s.ID == pion.Coordinate);
                    startPionField.PionOnPionField = pion;
                }
                else
                {
                    var startPionField = this.FirstOrDefault(s => s.ID == -(pion.PionNr + pion.PlayerHistory.PionOffset));
                    startPionField.PionOnPionField = pion;
                }
            }
        }

        public void MovePion(Pion pion, int steps)
        {
            PionDataService contactDS = new PionDataService();

            // get current PionField
            var PionField = this.FirstOrDefault(s => s.PionOnPionField == pion);
            int currentPionField;

            // IF: Move not valid [Checks 1]
            // - Is Out but no 6
            // - Is already Home
            // - Number of steps is bigger than the board
            if (pion.IsActive == false && steps != 6 ||
                pion.IsHome == true ||
                (pion.Coordinate + pion.PlayerHistory.PionOffset + steps) >= (44 + pion.PlayerHistory.PionOffset))
            {
                return;
            }

            // IF: Pion moved to Board
            if (pion.IsActive == false && steps == 6)
            {
                var startPionField = this.FirstOrDefault(s => s.ID == (1 + pion.PlayerHistory.PionOffset));
                currentPionField = startPionField.ID - steps;
            }

            // ELSE: Pion already on Board
            else
            {
                currentPionField = PionField.ID;
            }

            // Get next PionField
            var nextPionField = this.FirstOrDefault(s => s.ID == (currentPionField + steps));

            // IF: next PionField has Pion
            if (nextPionField.PionOnPionField != null)
            {
                // IF: Move not valid [Checks 2]
                // - If next pion is is of own Player
                if (pion.PlayerHistoryID == nextPionField.PionOnPionField.PlayerHistoryID)
                {
                    return;
                }

                // Move current Pion to Out
                var oldPion = nextPionField.PionOnPionField;
                oldPion.IsActive = false;
                oldPion.Coordinate = 1;

                var outPionField = this.FirstOrDefault(s => s.ID == -(oldPion.PionNr + oldPion.PlayerHistory.PionOffset));
                outPionField.PionOnPionField = oldPion;

                // Save currentPion to database
                contactDS.UpdatePion(oldPion);
            }

            // remove current selected Pion position from PionField
            PionField.PionOnPionField = null;

            // Move selected Pion to next PionField
            nextPionField.PionOnPionField = pion;
            pion.Coordinate = nextPionField.ID;

            // Make sure the pion's active as it passed all the checks
            pion.IsActive = true;

            // Save selected Pion to database
            contactDS.UpdatePion(pion);
        }
    }
}
