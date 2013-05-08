using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace MultiColumnTreeView
{
    public class Ship : INotifyPropertyChanged
    {

        private int _curFrame = 14;
        public int CurFrame
        {
            get { return _curFrame; }
            set
            {
                if (_curFrame != value)
                {
                    _curFrame = value;
                    NotifyPropertyChanged("CurFrame");
                }
            }
        }

        private string _name = "Ship Name";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private ObservableCollection<BallastSpace> _ballastSpaces = new ObservableCollection<BallastSpace>();
        public ReadOnlyObservableCollection<BallastSpace> BallastSpaces
        {
            get { return new ReadOnlyObservableCollection<BallastSpace>(_ballastSpaces); }
        }

        public void AddBallastSpace(BallastSpace ballastSpace)
        {
            _ballastSpaces.Add(ballastSpace);
            NotifyPropertyChanged("BallastSpaces");
        }

        public void RemoveBallastSpace(BallastSpace ballastSpace)
        {
            _ballastSpaces.Remove(ballastSpace);
            NotifyPropertyChanged("BallastSpaces");
        }

        private ObservableCollection<Space> _spaces = new ObservableCollection<Space>();
        public ReadOnlyObservableCollection<Space> Spaces
        {
            get { return new ReadOnlyObservableCollection<Space>(_spaces); }
        }

        public void AddSpace(Space space)
        {
            _spaces.Add(space);
            NotifyPropertyChanged("Spaces");
        }

        public void RemoveSpace(Space space)
        {
            _spaces.Remove(space);
            NotifyPropertyChanged("Spaces");
        }
    }
}
