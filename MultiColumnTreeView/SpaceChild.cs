using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MultiColumnTreeView
{
    public class SpaceChild : INotifyPropertyChanged 
    {

        public SpaceChild(BallastSpace ballastSpace, Space space)
        {
            Parent = ballastSpace;
            Space = space;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private BallastSpace _parent = null;
        private int _startFrame = 0;
        private int _endFrame = 0;
        private Space _space = null;
        private bool _isUsed = false;
        private bool _isSelected = false;

        public BallastSpace Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    NotifyPropertyChanged("Parent");
                }
            }
        }

        public int StartFrame
        {
            get { return _startFrame; }
            set
            {
                if (_startFrame != value)
                {
                    _startFrame = value;
                    NotifyPropertyChanged("StartFrame");
                }
            }
        }

        public int EndFrame
        {
            get { return _endFrame; }
            set
            {
                if (_endFrame != value)
                {
                    _endFrame = value;
                    NotifyPropertyChanged("EndFrame");
                }
            }
        }

        public Space Space
        {
            get { return _space; }
            set
            {
                if (_space != value)
                {
                    _space = value;
                    NotifyPropertyChanged("Space");
                }
            }
        }

        public bool IsUsed
        {
            get { return _isUsed; }
            set
            {
                if (_isUsed != value)
                {
                    _isUsed = value;
                    NotifyPropertyChanged("IsUsed");
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        public string Name
        {
            set
            { // do nothing 
            }
            get
            {
                    return "";
            }
        }

        public int TankLength
        {
            get { return 0; }
        }

        public int OverflowPosition
        {
            set { }
            get { return 0; }
        }

        public List<object> Children
        {
            get {return new List<object>();}
        }

    }
}
