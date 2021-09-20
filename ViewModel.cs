using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
namespace Kontrolna
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        Model CurrentModel;
        public ViewModel(Model model)
        {
            CurrentModel = model;
            UpdateEnumCell();
        }

        private readonly Random rand = new Random();
        private long[][] _cells = new long[4][] { new long[4], new long[4], new long[4], new long[4] };
        private async void UpdateEnumCell()
        {
            if (CurrentModel.HasFreeCell(_cells))
            {
                var fcell = CurrentModel.GetFreeCells(_cells);
                int cell_index = rand.Next() % fcell.Count();
                var tmp = fcell.ElementAt(cell_index);
                long cell_value = rand.Next() % 100;
                _cells[tmp.Item1][tmp.Item2] = (cell_value <= 10) ? 4 : 2;
            }

            Cell_1_1 = _cells[0][0].ToString();if(Cell_1_1=="0")Cell_1_1="";
            Cell_2_1 = _cells[1][0].ToString();if(Cell_2_1=="0")Cell_2_1="";
            Cell_3_1 = _cells[2][0].ToString();if(Cell_3_1=="0")Cell_3_1="";
            Cell_4_1 = _cells[3][0].ToString();if(Cell_4_1=="0")Cell_4_1="";
            Cell_1_2 = _cells[0][1].ToString();if(Cell_1_2=="0")Cell_1_2="";
            Cell_2_2 = _cells[1][1].ToString();if(Cell_2_2=="0")Cell_2_2="";
            Cell_3_2 = _cells[2][1].ToString();if(Cell_3_2=="0")Cell_3_2="";
            Cell_4_2 = _cells[3][1].ToString();if(Cell_4_2=="0")Cell_4_2="";
            Cell_1_3 = _cells[0][2].ToString();if(Cell_1_3=="0")Cell_1_3="";
            Cell_2_3 = _cells[1][2].ToString();if(Cell_2_3=="0")Cell_2_3="";
            Cell_3_3 = _cells[2][2].ToString();if(Cell_3_3=="0")Cell_3_3="";
            Cell_4_3 = _cells[3][2].ToString();if(Cell_4_3=="0")Cell_4_3="";
            Cell_1_4 = _cells[0][3].ToString();if(Cell_1_4=="0")Cell_1_4="";
            Cell_2_4 = _cells[1][3].ToString();if(Cell_2_4=="0")Cell_2_4="";
            Cell_3_4 = _cells[2][3].ToString();if(Cell_3_4=="0")Cell_3_4="";
            Cell_4_4 = _cells[3][3].ToString();if(Cell_4_4=="0")Cell_4_4="";
            for (int i = 1; i < 5; i++)
                for (int j = 1; j < 5; j++)
                    OnPropertyChanged($"Cell_{i}_{j}");
            if (CurrentModel.Exists(_cells, 2048))
            {
                InShowMenu = Visibility.Visible;
                await Task.Delay(1000);
                Win = Visibility.Visible;
                return;
            }
            if (!CurrentModel.CanMove(_cells))
            {
                InShowMenu = Visibility.Visible;
                await Task.Delay(1000);
                Lose = Visibility.Visible;
                return;
            }

            TotalScore = $"Total Score: {CurrentModel.Sum(_cells)}";
        }
        public string Cell_1_1 { get; set; }
        public string Cell_2_1 { get; set; }
        public string Cell_3_1 { get; set; }
        public string Cell_4_1 { get; set; }
        public string Cell_1_2 { get; set; }
        public string Cell_2_2 { get; set; }
        public string Cell_3_2 { get; set; }
        public string Cell_4_2 { get; set; }
        public string Cell_1_3 { get; set; }
        public string Cell_2_3 { get; set; }
        public string Cell_3_3 { get; set; }
        public string Cell_4_3 { get; set; }
        public string Cell_1_4 { get; set; }
        public string Cell_2_4 { get; set; }
        public string Cell_3_4 { get; set; }
        public string Cell_4_4 { get; set; }


        public Visibility _win = Visibility.Collapsed;

        public Visibility Win { get => _win; private set { _win = value; OnPropertyChanged("Win"); } }


        public Visibility _lose = Visibility.Collapsed;

        public Visibility Lose { get => _lose; private set { _lose = value; OnPropertyChanged("Lose"); } }


        private Visibility _in_show_menu = Visibility.Collapsed;

        public Visibility InShowMenu { get => _in_show_menu; private set { _in_show_menu = value; OnPropertyChanged("InShowMenu"); } }

        private string _total_score = string.Empty;

        public string TotalScore { get => _total_score; private set { _total_score = value; OnPropertyChanged("TotalScore"); } }

        private ICommand _resetLevel;
        public ICommand ResetLevel => _resetLevel ?? (_resetLevel = new DelegateCommand(() => {
            CurrentModel.Clear(ref _cells);
            UpdateEnumCell();
            Lose = Visibility.Collapsed;
            Win = Visibility.Collapsed;
            InShowMenu = Visibility.Collapsed;
        }));

        private ICommand _move_left;
        public ICommand MoveLeft => _move_left ?? (_move_left = new DelegateCommand(() => {
            if (!CurrentModel.CanMoveLeft(_cells)) return;
            CurrentModel.MoveLeft(ref _cells);
            UpdateEnumCell();
        }));
        private ICommand _move_right;
        public ICommand MoveRight => _move_right ?? (_move_right = new DelegateCommand(() => {
            if (!CurrentModel.CanMoveRight(_cells)) return;
            CurrentModel.MoveRight(ref _cells);
            UpdateEnumCell();
        }));
        private ICommand _move_down;
        public ICommand MoveDown => _move_down ?? (_move_down = new DelegateCommand(() => {
            if (!CurrentModel.CanMoveDown(_cells)) return;
            CurrentModel.MoveDown(ref _cells);
            UpdateEnumCell();
        }));
        private ICommand _move_up;
        public ICommand MoveUp => _move_up ?? (_move_up = new DelegateCommand(() => {
            if (!CurrentModel.CanMoveUp(_cells)) return;
            CurrentModel.MoveUp(ref _cells);
            UpdateEnumCell();
        }));
    }
}
